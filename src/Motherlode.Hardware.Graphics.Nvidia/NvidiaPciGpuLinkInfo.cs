using System.Xml.Serialization;

namespace Motherlode.Hardware.Graphics.Nvidia
{
	public class NvidiaPciGpuLinkInfo
	{
		[XmlElement("pcie_gen")]
		public NvidiaPciExpressGeneration PcieGeneration { get; set; }

		[XmlElement("link_widths")]
		public NvidiaPciLinkWidth LinkWidths { get; set; }
	}
}
