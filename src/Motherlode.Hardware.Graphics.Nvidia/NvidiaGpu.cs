using System;
using System.Xml.Serialization;

namespace Motherlode.Hardware.Graphics.Nvidia
{
	public class NvidiaGpu
	{
		[XmlAttribute("id")]
		public String Id { get; set; }

		[XmlElement("product_name")]
		public String ProductName { get; set; }

		[XmlElement("product_brand")]
		public String Brand { get; set; }

		[XmlElement("display_mode")]
		public String DisplayMode { get; set; }

		[XmlElement("display_active")]
		public String DisplayActive { get; set; }

		[XmlElement("persistence_mode")]
		public String PersistenceMode { get; set; }

		[XmlElement("accounting_mode")]
		public String AccountingMode { get; set; }

		[XmlElement("accounting_mode_buffer_size")]
		public String AccountingModeBufferSize { get; set; }

		//[XmlElement("driver_model")]
		//public String driver_model { get; set; }

		[XmlElement("serial")]
		public String Serial { get; set; }

		[XmlElement("uuid")]
		public String Uuid { get; set; }

		[XmlElement("minor_number")]
		public String MinorNumber { get; set; }

		[XmlElement("vbios_version")]
		public String VBiosVersion { get; set; }

		[XmlElement("multigpu_board")]
		public String MultiGpuBoard { get; set; }

		[XmlElement("board_id")]
		public String BoardId { get; set; }

		[XmlElement("gpu_part_number")]
		public String GpuPartNumber { get; set; }

		//[XmlElement("inforom_version")]
		//public String inforom_version { get; set; }

		//[XmlElement("gpu_operation_mode")]
		//public String gpu_operation_mode { get; set; }

		//[XmlElement("gpu_virtualization_mode")]
		//public String gpu_virtualization_mode { get; set; }

		[XmlElement("pci")]
		public NvidiaPci Pci { get; set; }

		[XmlElement("fan_speed")]
		public String FanSpeed { get; set; }

		[XmlElement("performance_state")]
		public String PerformanceState { get; set; }

		[XmlElement("clocks_throttle_reasons")]
		public NvidiaClockThrottleReasons ClocksThrottleReasons { get; set; }

		/// <summary>
		/// On-board frame buffer memory information. Reported total memory is affected by ECC state. If ECC is
		/// enabled the total available memory is decreased by several percent, due to the requisite parity bits.The
		/// driver may also reserve a small amount of memory for internal use, even without active work on the GPU.
		/// For all products.
		/// </summary>
		[XmlElement("fb_memory_usage")]
		public NvidiaMemoryUsage FrameBufferMemoryUsage { get; set; }

		/// <summary>
		/// BAR1 is used to map the FB (device memory) so that it can be directly accessed by the CPU or by 3rd
		/// party devices(peer-to-peer on the PCIe bus).
		/// </summary>
		[XmlElement("bar1_memory_usage")]
		public NvidiaMemoryUsage Bar1MemoryUsage { get; set; }

		/// <summary>
		/// The compute mode flag indicates whether individual or multiple compute applications may run on the
		/// 	"Default" means multiple contexts are allowed per device.
		/// 	"Exclusive Process" means only one context is allowed per device, usable from multiple threads at a time.
		/// 	"Prohibited" means no contexts are allowed per device (no compute apps).
		/// 	"EXCLUSIVE_PROCESS" was added in CUDA 4.0. Prior CUDA releases supported only one exclusive
		/// 		mode, which is equivalent to "EXCLUSIVE_THREAD" in CUDA 4.0 and beyond.
		/// For all CUDA-capable products.
		/// </summary>
		[XmlElement("compute_mode")]
		public String ComputeMode { get; set; }

		[XmlElement("utilization")]
		public NvidiaUtilization Utilization { get; set; }

		[XmlElement("ecc_mode")]
		public NvidiaEccMode EccMode { get; set; }

		[XmlElement("ecc_errors")]
		public NvidiaEccErrors EccErrors { get; set; }

		[XmlElement("retired_pages")]
		public NvidiaRetiredPages RetiredPages { get; set; }

		[XmlElement("temperature")]
		public NvidiaTempurature Temperature { get; set; }

		[XmlElement("power_readings")]
		public NvidiaPowerReadings PowerReadings { get; set; }

		[XmlElement("clocks")]
		public NvidiaClocks Clocks { get; set; }

		[XmlElement("applications_clocks")]
		public NvidiaClocks ApplicationClocks { get; set; }

		[XmlElement("default_applications_clocks")]
		public NvidiaClocks DefaultApplicationClocks { get; set; }

		[XmlElement("max_clocks")]
		public NvidiaClocks MaxClocks { get; set; }

		[XmlElement("clock_policy")]
		public NvidiaClockPolicy ClockPolicy { get; set; }

		/// <summary>
		/// List of possible memory and graphics clocks combinations that the GPU can operate on(not taking into
		/// account HW brake reduced clocks). These are the only clock combinations that can be passed to −−applications−
		/// clocks flag.Supported Clocks are listed only when −q −d SUPPORTED_CLOCKS switches are
		/// provided or in XML format.
		/// </summary>
		[XmlArray("supported_clocks")]
		[XmlArrayItem("supported_mem_clock")]
		public NvidiaSupportedClock[] SupportedClocks { get; set; }

		[XmlArray("processes")]
		[XmlArrayItem("process_info")]
		public NvidiaProcessInfo[] Processes { get; set; }

		//[XmlElement("accounted_processes")]
		//public String AccountedProcesses { get; set; }
	}
}
