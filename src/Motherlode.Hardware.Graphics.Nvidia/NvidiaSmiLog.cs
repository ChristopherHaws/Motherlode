using System;
using System.Xml.Serialization;

namespace Motherlode.Hardware.Graphics.Nvidia
{
	[XmlRoot("nvidia_smi_log")]
	public class NvidiaSmiLog
	{
		[XmlElement("timestamp")]
		public String Timestamp { get; set; }

		[XmlElement("driver_version")]
		public String DriverVersion { get; set; }

		[XmlElement("attached_gpus")]
		public Int32 AttachedGpus { get; set; }

		[XmlElement("gpu")]
		public NvidiaGpu[] Gpus { get; set; }
	}
}
