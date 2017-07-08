using System;
using System.Xml.Serialization;

namespace Motherlode.Hardware.Graphics.Nvidia
{
	public class NvidiaProcessInfo
	{
		[XmlElement("pid")]
		public String ProcessId { get; set; }

		[XmlElement("type")]
		public String Type { get; set; }

		[XmlElement("process_name")]
		public String Name { get; set; }

		[XmlElement("used_memory")]
		public String UsedMemory { get; set; }
	}
}
