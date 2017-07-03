using Motherlode.Common.Miners;

namespace Motherlode.Miners.Ewbf
{
	public class EwbfMiner : ProcessMiner
	{
		public EwbfMiner(IMinerLog log)
			: base(log)
		{
		}

		public override ProcessMinerStartInfo GetStartInfo()
		{
			return new ProcessMinerStartInfo
			{
				ExecutablePath = @"c:\Users\chaws\Desktop\test.bat"
			};
		}
	}
}
