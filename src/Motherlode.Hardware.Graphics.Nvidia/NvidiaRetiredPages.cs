using System;
using System.Xml.Serialization;

namespace Motherlode.Hardware.Graphics.Nvidia
{
	public class NvidiaRetiredPages
	{
		[XmlElement("multiple_single_bit_retirement")]
		public NvidiaRetiredPage MultipleSingleBitRetirement { get; set; }

		[XmlElement("double_bit_retirement")]
		public NvidiaRetiredPage DoubleBitRetirement { get; set; }

		[XmlElement("pending_retirement")]
		public String PendingRetirement { get; set; }
	}
}
