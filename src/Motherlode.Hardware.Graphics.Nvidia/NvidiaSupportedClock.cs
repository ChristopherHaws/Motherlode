using System;
using System.Xml.Serialization;

namespace Motherlode.Hardware.Graphics.Nvidia
{
	public class NvidiaSupportedClock
	{
		[XmlElement("value")]
		public UnitOfMeasure<Int32> MemoryClock { get; set; }

		[XmlElement("supported_graphics_clock")]
		public UnitOfMeasure<Int32>[] SupportedGraphicsClocks { get; set; }
	}
}
