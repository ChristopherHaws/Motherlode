using System;
using System.Xml.Serialization;

namespace Motherlode.Hardware.Graphics.Nvidia
{
	public class NvidiaPciLinkWidth
	{
		[XmlElement("max_link_width")]
		public String MaxLinkWidth { get; set; }

		[XmlElement("current_link_width")]
		public String CurrentLinkWidth { get; set; }
	}
}
