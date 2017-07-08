using System;
using System.Xml.Serialization;

namespace Motherlode.Hardware.Graphics.Nvidia
{
	public class NvidiaClockPolicy
	{
		[XmlElement("auto_boost")]
		public String AutoBoost { get; set; }

		[XmlElement("auto_boost_default")]
		public String AutoBoostDefault { get; set; }
	}
}
