using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Motherlode.Miners.Ewbf.Configuration
{
	public class EwbfConfigurationWriter
	{
		public void Write(String path, EwbfConfiguration configuration)
		{
			var builder = new StringBuilder();

			WriteCommonParameters(builder, configuration);

			foreach (var server in configuration.Servers)
			{
				WriteServerParameters(builder, server);
			}

			File.WriteAllText(path, builder.ToString());
		}

		private static void WriteCommonParameters(StringBuilder builder, EwbfConfiguration configuration)
		{
			builder.AppendLine("[common]");

			builder.Append("cuda_devices ");
			builder.AppendLine(String.Join(" ", configuration.CudaDevices.Select(x => x.Id)));

			builder.Append("intensity ");
			builder.AppendLine(String.Join(" ", configuration.CudaDevices.Select(x => x.Intensity)));

			builder.Append("templimit ");
			builder.AppendLine(configuration.TempuratureLimit.ToString());

			builder.Append("pec ");
			builder.AppendLine(configuration.CalculatePowerEfficiency ? "1" : "0");

			builder.AppendLine("boff 1");
			builder.AppendLine("eexit 1");

			builder.Append("tempunity ");
			builder.AppendLine(configuration.TempuratureScale == TempuratureScale.Celcius ? "c" : "f");

			builder.Append("log ");
			builder.AppendLine(configuration.LogLevel.ToString());

			builder.Append("logfile ");
			builder.AppendLine(configuration.LogFile);

			builder.AppendLine("api 0.0.0.0:42000");
			builder.AppendLine();
		}

		private static void WriteServerParameters(StringBuilder builder, StratumServer server)
		{
			builder.AppendLine("[server]");
			
			builder.Append("server ");
			builder.AppendLine(server.Address);

			builder.Append("port ");
			builder.AppendLine(server.Port.ToString());

			builder.Append("user ");
			builder.AppendLine(server.Username);

			builder.Append("password ");
			builder.AppendLine(server.Password);

			builder.AppendLine();
		}
	}
}
