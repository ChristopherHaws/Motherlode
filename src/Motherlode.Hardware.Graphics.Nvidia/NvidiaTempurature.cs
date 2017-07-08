using System;
using System.Xml.Serialization;

namespace Motherlode.Hardware.Graphics.Nvidia
{
	public class NvidiaTempurature
	{
		[XmlElement("gpu_temp")]
		public UnitOfMeasure<Int32> Tempurature { get; set; }

		[XmlElement("gpu_temp_max_threshold")]
		public UnitOfMeasure<Int32> TempuratureMaxThreshold { get; set; }

		[XmlElement("gpu_temp_slow_threshold")]
		public UnitOfMeasure<Int32> TempuratureSlowThreshold { get; set; }
	}
}
