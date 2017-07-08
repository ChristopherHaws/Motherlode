using System;
using System.Xml.Serialization;

namespace Motherlode.Hardware.Graphics.Nvidia
{
	public class NvidiaEccMode
	{
		[XmlElement("current_ecc")]
		public String CurrentEcc { get; set; }

		[XmlElement("pending_ecc")]
		public String PendingEcc { get; set; }
	}
}
