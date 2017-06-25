using System;
using System.IO;
using System.IO.Compression;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Motherlode.Miners.Ewbf
{
	public class EwbfClient
	{
		public EwbfClient(String baseUrl)
		{
			var uri = new Uri(baseUrl);

			this.Host = uri.Host;
			this.Port = uri.Port;
		}

		public EwbfClient(String host, Int32 port)
		{
			this.Host = host;
			this.Port = port;
		}

		public String Host { get; }

		public Int32 Port { get; }

		public Int32 SendTimeout { get; set; } = 500;

		public Int32 ReceiveTimeout { get; set; } = 1000;

		public async Task<GetStatResponse> GetStatistics()
		{
			var data = await this.Get("/getstat");

			return JsonConvert.DeserializeObject<GetStatResponse>(data);
		}

		private async Task<String> Get(String absolutePath, String body = null)
		{
			String result = null;

			using (var client = new TcpClient())
			{
				await client.ConnectAsync(this.Host, this.Port);

				using (var stream = client.GetStream())
				{
					client.SendTimeout = this.SendTimeout;
					client.ReceiveTimeout = this.ReceiveTimeout;

					// Send request headers
					var builder = new StringBuilder();
					builder.Append("GET ");
					builder.Append(absolutePath);
					builder.AppendLine(" HTTP/1.1");
					builder.Append("Host: ");
					builder.AppendLine(this.Host);

					if (body != null)
					{
						// only for POST request
						builder.AppendLine("Content-Length: " + body.Length);
					}

					builder.AppendLine("Connection: close");
					builder.AppendLine();

					var header = Encoding.ASCII.GetBytes(builder.ToString());

					await stream.WriteAsync(header, 0, header.Length);

					// Send payload data if you are POST request
					if (body != null)
					{
						var bodyData = Encoding.ASCII.GetBytes(body);
						await stream.WriteAsync(bodyData, 0, bodyData.Length);
					}

					// receive data
					using (var memory = new MemoryStream())
					{
						await stream.CopyToAsync(memory);
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

		private static int BinaryMatch(byte[] input, byte[] pattern)
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
