using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Motherlode.Hardware.Graphics.Nvidia
{
	public struct UnitOfMeasure<T> : IXmlSerializable
		where T : IConvertible
	{
		public String OriginalValue { get; set; }

		public T Value { get; set; }

		public String Symbol { get; set; }

		public XmlSchema GetSchema() => null;

		public void ReadXml(XmlReader reader)
		{
			this.OriginalValue = reader.ReadElementContentAsString();

			if (String.IsNullOrWhiteSpace(this.OriginalValue))
			{
				return;
			}

			var split = this.OriginalValue.Split(' ');
			if (split.Length < 2)
			{
				return;
			}

			this.Value = (T)Convert.ChangeType(split[0], typeof(T));
			this.Symbol = split[1];
		}

		public void WriteXml(XmlWriter writer)
		{
			throw new NotImplementedException();
		}

		public override String ToString() => $"{this.Value} {this.Symbol}";
	}
}
