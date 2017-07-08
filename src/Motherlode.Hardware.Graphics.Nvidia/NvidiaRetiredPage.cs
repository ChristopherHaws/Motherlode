using System;
using System.Xml.Serialization;

namespace Motherlode.Hardware.Graphics.Nvidia
{
	public class NvidiaRetiredPage
	{
		[XmlElement("retired_count")]
		public String RetiredCount { get; set; }

		[XmlElement("retired_page_addresses")]
		public String RetiredPageAddresses { get; set; }
	}
}
