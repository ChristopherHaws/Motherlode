using System;
using Motherlode.Common.CommandQuery;

namespace Motherlode.Common.Hardware.Graphics
{
	public interface ITempuratureProvider
	{
		Decimal GetTempurature(Int32 gpuId);
	}

	public interface IPowerUsageProvider
	{
		Decimal GetPowerUsage(Int32 gpuId);
	}

	public class GetHashRateQuery : IQuery<GetHashRateQuery.Result>
	{
		public Int32 GpuId { get; set; }

		public class Result
		{
			public Decimal Rate { get; set; }

			public String UnitOfMeasure { get; set; }
		}
	}
}
