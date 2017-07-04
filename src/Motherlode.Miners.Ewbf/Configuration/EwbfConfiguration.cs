using System;
using System.Collections.Generic;

namespace Motherlode.Miners.Ewbf.Configuration
{
	public class EwbfConfiguration
	{
		public List<Device> CudaDevices { get; set; }

		public Int32 TempuratureLimit { get; set; }

		public TempuratureScale TempuratureScale { get; set; }

		public Boolean CalculatePowerEfficiency { get; set; }

		public Int32 LogLevel { get; set; }

		public String LogFile { get; set; }

		public List<StratumServer> Servers { get; set; }
	}
}
