using System;
using System.Xml.Serialization;

namespace Motherlode.Hardware.Graphics.Nvidia
{
	public class NvidiaUtilization
	{
		[XmlElement("gpu_util")]
		public UnitOfMeasure<Int32> GpuUtilization { get; set; }

		[XmlElement("memory_util")]
		public UnitOfMeasure<Int32> MemoryUtilization { get; set; }

		[XmlElement("encoder_util")]
		public UnitOfMeasure<Int32> EncoderUtilization { get; set; }

		[XmlElement("decoder_util")]
		public UnitOfMeasure<Int32> DecoderUtilization { get; set; }
	}
}
