using System.Xml.Serialization;

namespace Motherlode.Hardware.Graphics.Nvidia
{
	public class NvidiaEccErrorBits
	{
		[XmlElement("single_bit")]
		public NvidiaEccError SingleBit { get; set; }

		[XmlElement("double_bit")]
		public NvidiaEccError DoubleBit { get; set; }
	}
}
