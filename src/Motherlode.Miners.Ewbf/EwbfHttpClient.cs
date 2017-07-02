using System;
using System.IO;
using System.IO.Compression;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Motherlode.Miners.Ewbf
{
	/// <summary>
	/// This class is a bit of a hack. It is needed because EWBF isn't implementing the HTTP protocol properly.
	/// See: https://github.com/nanopool/ewbf-miner/issues/14
	/// </summary>
	internal class EwbfHttpClient : IDisposable
	{
		public Int32 SendTimeout { get; set; } = 500;

		public Int32 ReceiveTimeout { get; set; } = 1000;

		public void Dispose()
		{
			// NOOP: Might need this in the future and I want to keep the same signitures as HttpClient...
		}

		public Task<String> GetAsync(Uri uri)
		{
			return this.ExecuteAsync(uri);
		}

		private async Task<String> ExecuteAsync(Uri uri, String body = null)
		{
			String result = null;

			using (var client = new TcpClient())
			{
				await client.ConnectAsync(uri.Host, uri.Port).ConfigureAwait(false);

				using (var stream = client.GetStream())
				{
					client.SendTimeout = this.SendTimeout;
					client.ReceiveTimeout = this.ReceiveTimeout;

					// Send request headers
					var builder = new StringBuilder();
					builder.Append("GET ");
					builder.Append(uri.AbsolutePath);
					builder.AppendLine(" HTTP/1.1");
					builder.Append("Host: ");
					builder.AppendLine(uri.Host);

					if (body != null)
					{
						// only for POST request
						builder.AppendLine("Content-Length: " + body.Length);
					}

					builder.AppendLine("Connection: close");
					builder.AppendLine();

					var header = Encoding.ASCII.GetBytes(builder.ToString());

					await stream.WriteAsync(header, 0, header.Length).ConfigureAwait(false);

					// Send payload data if you are POST request
					if (body != null)
					{
						var bodyData = Encoding.ASCII.GetBytes(body);
						await stream.WriteAsync(bodyData, 0, bodyData.Length).ConfigureAwait(false);
					}

					// receive data
					using (var memory = new MemoryStream())
					{
						await stream.CopyToAsync(memory).ConfigureAwait(false);
						memory.Position = 0;
						var data = memory.ToArray();

						Encoding.ASCII.GetString(data, 0, data.Length);

						var index = BinaryMatch(data, Encoding.ASCII.GetBytes("\n\n")) + 2;
						var headers = Encoding.ASCII.GetString(data, 0, index);
						memory.Position = index;

						if (headers.IndexOf("Content-Encoding: gzip") > 0)
						{
							using (GZipStream decompressionStream = new GZipStream(memory, CompressionMode.Decompress))
							using (var decompressedMemory = new MemoryStream())
							{
								decompressionStream.CopyTo(decompressedMemory);
								decompressedMemory.Position = 0;
								result = Encoding.UTF8.GetString(decompressedMemory.ToArray());
							}
						}
						else
						{
							result = Encoding.UTF8.GetString(data, index, data.Length - index);
							//result = Encoding.GetEncoding("gbk").GetString(data, index, data.Length - index);
						}
					}

					return result;
				}
			}
		}

		private static int BinaryMatch(Byte[] input, Byte[] pattern)
		{
			var length = input.Length - pattern.Length + 1;

			for (var i = 0; i < length; ++i)
			{
				var match = true;

				for (var j = 0; j < pattern.Length; ++j)
				{
					if (input[i + j] != pattern[j])
					{
						match = false;
						break;
					}
				}

				if (match)
				{
					return i;
				}
			}

			return -1;
		}
	}
}
