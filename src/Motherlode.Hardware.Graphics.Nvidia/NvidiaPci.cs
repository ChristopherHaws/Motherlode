using System;
using System.Xml.Serialization;

namespace Motherlode.Hardware.Graphics.Nvidia
{
	public class NvidiaPci
	{
		[XmlElement("pci_bus")]
		public String Bus { get; set; }

		[XmlElement("pci_device")]
		public String Device { get; set; }

		[XmlElement("pci_domain")]
		public String Domain { get; set; }

		[XmlElement("pci_device_id")]
		public String DeviceId { get; set; }

		[XmlElement("pci_bus_id")]
		public String BusId { get; set; }

		[XmlElement("pci_sub_system_id")]
		public String SubSystemId { get; set; }

		[XmlElement("pci_gpu_link_info")]
		public NvidiaPciGpuLinkInfo GpuLinkInfo { get; set; }

		[XmlElement("pci_bridge_chip")]
		public NvidiaPciBridgeChip BridgeChip { get; set; }

		[XmlElement("replay_counter")]
		public String ReplayCounter { get; set; }

		/// <summary>
		/// The GPU-centric transmission throughput across the PCIe bus in MB/s over the past 20ms. Only supported on Maxwell architectures and newer.
		/// </summary>
		[XmlElement("tx_util")]
		public UnitOfMeasure<Int32> TxUtilization { get; set; }

		/// <summary>
		/// The GPU-centric receive throughput across the PCIe bus in MB/s over the past 20ms. Only supported on Maxwell architectures and newer.
		/// </summary>
		[XmlElement("rx_util")]
		public UnitOfMeasure<Int32> RxUtilization { get; set; }
	}
}
