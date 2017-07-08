using System;
using System.Xml.Serialization;

namespace Motherlode.Hardware.Graphics.Nvidia
{
	public class NvidiaClocks
	{
		[XmlElement("graphics_clock")]
		public UnitOfMeasure<Int32> GraphicsClock { get; set; }

		[XmlElement("sm_clock")]
		public UnitOfMeasure<Int32> StreamingMultiprocessorClock { get; set; }

		[XmlElement("mem_clock")]
		public UnitOfMeasure<Int32> MemoryClock { get; set; }

		[XmlElement("video_clock")]
		public UnitOfMeasure<Int32> VideoClock { get; set; }
	}
}
