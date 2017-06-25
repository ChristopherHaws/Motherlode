using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Motherlode.Common;
using Newtonsoft.Json;

namespace Motherlode.Miners.Ewbf
{
	public class GetStatResponse
	{
		/// <summary>
		/// Gets or sets the id from request or 0 in other case.
		/// </summary>
		[NotNull]
		[JsonProperty("id")]
		public Int32 Id { get; set; }

		/// <summary>
		/// Gets or sets the method name
		/// </summary>
		[NotNull]
		[JsonProperty("method")]
		public String Method { get; set; }

		/// <summary>
		/// Gets or sets the error message. Null if no error.
		/// </summary>
		[CanBeNull]
		[JsonProperty("error")]
		public String Error { get; set; }

		/// <summary>
		/// Gets or sets the time when miner was started (availaible since version 0.3.4b)
		/// </summary>
		[NotNull]
		[JsonProperty("start_time")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime StartUtcDateTime { get; set; }

		/// <summary>
		/// Gets or sets the current server name (availaible since 0.3.4b)
		/// </summary>
		[NotNull]
		[JsonProperty("current_server")]
		public String CurrentServer { get; set; }

		/// <summary>
		/// Gets or sets the number of available stratum servers (availaible since 0.3.4b)
		/// </summary>
		[NotNull]
		[JsonProperty("available_servers")]
		public Int32 AvailableServers { get; set; }

		/// <summary>
		/// Gets or sets the status of current server.  (availaible since 0.3.4b)
		/// </summary>
		[NotNull]
		[JsonProperty("server_status")]
		public ServerStatus ServerStatus { get; set; }

		/// <summary>
		/// Gets or sets the gpu statistics.
		/// </summary>
		[NotNull]
		[JsonProperty("result")]
		public IList<GpuStatistics> Result { get; set; }
	}
}
