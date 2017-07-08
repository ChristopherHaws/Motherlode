using System.Xml.Serialization;

namespace Motherlode.Hardware.Graphics.Nvidia
{
	public class NvidiaEccErrors
	{
		[XmlElement("volatile")]
		public NvidiaEccErrorBits Volatile { get; set; }

		[XmlElement("aggregate")]
		public NvidiaEccErrorBits Aggregate { get; set; }
	}
}
