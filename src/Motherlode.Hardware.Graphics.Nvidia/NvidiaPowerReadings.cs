using System;
using System.Xml.Serialization;

namespace Motherlode.Hardware.Graphics.Nvidia
{
	public class NvidiaPowerReadings
	{
		[XmlElement("power_state")]
		public String PowerState { get; set; }

		[XmlElement("power_management")]
		public String PowerManagement { get; set; }

		[XmlElement("power_draw")]
		public UnitOfMeasure<Decimal> PowerDraw { get; set; }

		[XmlElement("power_limit")]
		public UnitOfMeasure<Decimal> PowerLimit { get; set; }

		[XmlElement("default_power_limit")]
		public UnitOfMeasure<Decimal> DefaultPowerLimit { get; set; }

		[XmlElement("enforced_power_limit")]
		public UnitOfMeasure<Decimal> EnforcedPowerLimit { get; set; }

		[XmlElement("min_power_limit")]
		public UnitOfMeasure<Decimal> MinPowerLimit { get; set; }

		[XmlElement("max_power_limit")]
		public UnitOfMeasure<Decimal> MaxPowerLimit { get; set; }
	}
}
