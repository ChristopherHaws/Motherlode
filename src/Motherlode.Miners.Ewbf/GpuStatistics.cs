using System;
using JetBrains.Annotations;
using Motherlode.Common;
using Newtonsoft.Json;

namespace Motherlode.Miners.Ewbf
{
	/// <summary>
	/// Remark: temperature, gpu_power_usage and speed_sps updated every 30 seconds.
	/// </summary>
	public class GpuStatistics
	{
		/// <summary>
		/// Gets or sets the internal gpu identifier
		/// </summary>
		[NotNull]
		[JsonProperty("gpuid")]
		public Int32 GpuId { get; set; }

		/// <summary>
		/// Gets or sets the gpu cuda identifier
		/// </summary>
		[NotNull]
		[JsonProperty("cudaid")]
		public Int32 CudaId { get; set; }

		/// <summary>
		/// Gets or sets the pci bus id in format: 0000:00:00.0
		/// </summary>
		[NotNull]
		[JsonProperty("busid")]
		public String BusId { get; set; }

		/// <summary>
		/// Gets or sets the name of gpu (availaible since 0.3.4b)
		/// </summary>
		[NotNull]
		[JsonProperty("name")]
		public String Name { get; set; }

		/// <summary>
		/// Gets or sets the status of gpu 
		/// </summary>
		[NotNull]
		[JsonProperty("gpu_status")]
		public GpuStatus Status { get; set; }

		/// <summary>
		/// Gets or sets the selected solver
		/// </summary>
		[NotNull]
		[JsonProperty("solver")]
		public Int32 Solver { get; set; }

		/// <summary>
		/// Gets or sets the gpu core temperature
		/// </summary>
		[NotNull]
		[JsonProperty("temperature")]
		public Int32 Temperature { get; set; }

		/// <summary>
		/// Gets or sets the gpu power usage in watts, not all devices support this in this case this value will be 0
		/// </summary>
		[NotNull]
		[JsonProperty("gpu_power_usage")]
		public Int32 GpuPowerUsage { get; set; }

		/// <summary>
		/// Gets or sets the gpu performance in solutions per seconds
		/// </summary>
		[NotNull]
		[JsonProperty("speed_sps")]
		public Int32 SolutionPerSecond { get; set; }

		/// <summary>
		/// Gets or sets the amount of accepted shares
		/// </summary>
		[NotNull]
		[JsonProperty("accepted_shares")]
		public Int32 AcceptedShares { get; set; }

		/// <summary>
		/// Gets or sets the amount of rejected shares
		/// </summary>
		[NotNull]
		[JsonProperty("rejected_shares")]
		public Int32 RejectedShares { get; set; }

		/// <summary>
		/// Gets or sets the time when the worker was started (availaible since 0.3.4b)
		/// </summary>
		[NotNull]
		[JsonProperty("start_time")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime StartUtcDateTime { get; set; }
	}
}
