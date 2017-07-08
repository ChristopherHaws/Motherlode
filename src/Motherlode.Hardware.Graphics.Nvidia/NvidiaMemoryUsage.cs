using System;
using System.Xml.Serialization;

namespace Motherlode.Hardware.Graphics.Nvidia
{
	public class NvidiaMemoryUsage
	{
		[XmlElement("total")]
		public UnitOfMeasure<Int32> Total { get; set; }

		[XmlElement("used")]
		public UnitOfMeasure<Int32> Used { get; set; }

		[XmlElement("free")]
		public UnitOfMeasure<Int32> Free { get; set; }
	}
}
