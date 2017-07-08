using System;
using System.Xml.Serialization;

namespace Motherlode.Hardware.Graphics.Nvidia
{
	public class NvidiaPciBridgeChip
	{
		[XmlElement("bridge_chip_type")]
		public String BridgeChipType { get; set; }

		[XmlElement("bridge_chip_fw")]
		public String BridgeChipFirmware { get; set; }
	}
}
