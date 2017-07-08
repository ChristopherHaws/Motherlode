using System;
using System.Xml.Serialization;

namespace Motherlode.Hardware.Graphics.Nvidia
{
	public class NvidiaPciExpressGeneration
	{
		[XmlElement("max_link_gen")]
		public String MaxLinkGeneration { get; set; }

		[XmlElement("current_link_gen")]
		public String CurrentLinkGeneration { get; set; }
	}
}
