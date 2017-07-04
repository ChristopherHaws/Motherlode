using System;
using System.IO;
using Motherlode.Common.Miners;
using Motherlode.Miners.Ewbf.Configuration;

namespace Motherlode.Miners.Ewbf
{
	public class EwbfMiner : ProcessMiner
	{
		private readonly String path;
		private readonly String name;
		private readonly EwbfConfiguration configuration;

		public EwbfMiner(IMinerLog log, String path, String name, EwbfConfiguration configuration)
			: base(log)
		{
			this.path = path;
			this.name = name;
			this.configuration = configuration;
		}

		public override ProcessMinerStartInfo GetStartInfo()
		{
			var configurationWriter = new EwbfConfigurationWriter();

			var configFileName = this.name + ".cfg";
			var configFilePath = Path.Combine(this.path, configFileName);
			var minerFilePath = Path.Combine(this.path, "miner.exe");

			configurationWriter.Write(configFilePath, this.configuration);

			return new ProcessMinerStartInfo
			{
				ExecutablePath = minerFilePath,
				Arguments = $"--config \"{configFilePath}\""
			};
		}
	}
}
