using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace Motherlode.Hardware.Graphics.Nvidia
{
	public class NvidiaSmi
	{
		private readonly String path;

		public NvidiaSmi()
		{
			// Linux Locations
			//	/usr/bin/nvidia-smi
			//	/usr/bin/nvidia-settings

			this.path = @"C:\Program Files\NVIDIA Corporation\NVSMI\nvidia-smi.exe";
		}

		public String GetPowerDraw()
		{
			return this.RunCommand(@"--query-gpu=power.draw --format=csv");
		}

		public NvidiaSmiLog GetAll()
		{
			var xml = this.RunCommand(@"-q -x");

			var serializer = new XmlSerializer(typeof(NvidiaSmiLog));

			using (TextReader reader = new StringReader(xml))
			{
				return (NvidiaSmiLog)serializer.Deserialize(reader);
			}
		}

		/// <summary>
		/// Specifies maximum <memory,graphics> clocks (e.g. 2000,800) that defines GPU’s speed while
		/// running applications on a GPU. For Tesla devices from the Kepler+ family and Maxwell-based GeForce
		/// Titan. Requires root unless restrictions are relaxed with the −acp command.
		/// </summary>
		public void SetApplicationClocks(Int32 gpuId, Decimal memoryClock, Decimal graphicsClock)
		{
			this.RunCommand($"--applications-clocks={memoryClock},{graphicsClock} --id={gpuId}");
		}

		/// <summary>
		/// Specifies maximum power limit in watts. Accepts integer and floating point numbers. Only on supported
		/// devices from Kepler family.Requires administrator privileges. Value needs to be between Min and Max
		/// Power Limit as reported by nvidia-smi.
		/// </summary>
		public Boolean SetPowerLimit(Int32 gpuId, Decimal watts)
		{
			this.RunCommand($"--power-limit={watts} --id={gpuId}");

			return true;
		}

		/// <summary>
		/// Trigger a reset of the GPU.Can be used to clear GPU HW and SW state in situations that would otherwise
		/// require a machine reboot. Typically useful if a double bit ECC error has occurred. Requires −i switch to
		/// target specific device. Requires root. There can't be any applications using this particular device (e.g.
		/// CUDA application, graphics application like X server, monitoring application like other instance of nvidiasmi).
		/// There also can't be any compute applications running on any other GPU in the system. Only on supported
		/// devices from Fermi and Kepler family running on Linux.
		///
		/// GPU reset is not guaranteed to work in all cases. It is not recommended for production environments at this
		/// time. In some situations there may be HW components on the board that fail to revert back to an initial
		/// state following the reset request. This is more likely to be seen on Fermi-generation products vs.Kepler,
		/// and more likely to be seen if the reset is being performed on a hung GPU.
		///
		/// Following a reset, it is recommended that the health of the GPU be verified before further use. The nvidiahealthmon
		/// tool is a good choice for this test.If the GPU is not healthy a complete reset should be instigated
		/// by power cycling the node.
		/// </summary>
		public void Reset(Int32 gpuId)
		{
			this.RunCommand($"-−gpu−reset --id={gpuId}");
		}

		private String RunCommand(String arguments)
		{
			var process = new Process
			{
				StartInfo = new ProcessStartInfo(this.path, arguments)
				{
					CreateNoWindow = true,
					UseShellExecute = false,
					RedirectStandardOutput = true,
					RedirectStandardError = true
				}
			};

			process.Start();

			var data = process.StandardOutput.ReadToEnd();

			process.WaitForExit();

			switch (process.ExitCode)
			{
				case 0:
					return data;
				case 2:
					throw new Exception("A supplied argument or flag is invalid");
				case 3:
					throw new Exception("The requested operation is not available on target device");
				case 4:
					throw new Exception("The current user does not have permission to access this device or perform this operation");
				case 6:
					throw new Exception("A query to find an object was unsuccessful");
				case 8:
					throw new Exception("A device’s external power cables are not properly attached");
				case 9:
					throw new Exception("NVIDIA driver is not loaded");
				case 10:
					throw new Exception("NVIDIA Kernel detected an interrupt issue with a GPU");
				case 12:
					throw new Exception("NVML Shared Library couldn’t be found or loaded");
				case 13:
					throw new Exception("Local version of NVML doesn’t implement this function");
				case 14:
					throw new Exception("infoROM is corrupted");
				case 15:
					throw new Exception("The GPU has fallen off the bus or has otherwise become inaccessible");
				case 255:
					throw new Exception("Other error or internal driver error occurred");
				default:
					throw new Exception($"Unknown exit code {process.ExitCode}.");
			}
		}
	}
}
