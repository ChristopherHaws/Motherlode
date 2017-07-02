using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Motherlode.Miners.Ewbf
{
	public class EwbfClient
	{
		public EwbfClient(String baseUrl)
		{
			this.BaseUri = new Uri(baseUrl);
		}

		public EwbfClient(String host, Int32 port)
		{
			var builder = new UriBuilder("HTTP", host, port);
			this.BaseUri = builder.Uri;
		}

		public Uri BaseUri { get; }

		public async Task<GetStatResponse> GetStatistics()
		{
			using (var client = new EwbfHttpClient())
			{
				var respose = await client.GetAsync(new Uri(this.BaseUri, "/getstat"));

				return JsonConvert.DeserializeObject<GetStatResponse>(respose);
			}
		}
	}
}
