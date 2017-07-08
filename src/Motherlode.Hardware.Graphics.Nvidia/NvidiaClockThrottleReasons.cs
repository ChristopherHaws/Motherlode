using System;
using System.Xml.Serialization;

namespace Motherlode.Hardware.Graphics.Nvidia
{
	public class NvidiaClockThrottleReasons
	{
		[XmlElement("clocks_throttle_reason_gpu_idle")]
		public String GpuIdle { get; set; }

		[XmlElement("clocks_throttle_reason_applications_clocks_setting")]
		public String ApplicationClockSettings { get; set; }

		[XmlElement("clocks_throttle_reason_sw_power_cap")]
		public String SoftwarePowerCap { get; set; }

		[XmlElement("clocks_throttle_reason_hw_slowdown")]
		public String HardwareSlowdown { get; set; }

		[XmlElement("clocks_throttle_reason_sync_boost")]
		public String SyncBoost { get; set; }

		[XmlElement("clocks_throttle_reason_unknown")]
		public String Unknown { get; set; }
	}
}
