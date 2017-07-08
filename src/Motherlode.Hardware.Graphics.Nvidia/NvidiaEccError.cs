using System;
using System.Xml.Serialization;

namespace Motherlode.Hardware.Graphics.Nvidia
{
	public class NvidiaEccError
	{
		[XmlElement("device_memory")]
		public String DeviceMemory { get; set; }

		[XmlElement("register_file")]
		public String RegisterFile { get; set; }

		[XmlElement("l1_cache")]
		public String L1Cache { get; set; }

		[XmlElement("l2_cache")]
		public String L2Cache { get; set; }

		[XmlElement("texture_memory")]
		public String TextureMemory { get; set; }

		[XmlElement("texture_shm")]
		public String TextureShm { get; set; }

		[XmlElement("total")]
		public String Total { get; set; }
	}
}
