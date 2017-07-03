using System;
using System.IO;

namespace Motherlode.Common.Miners
{
	public class FileMinerLog : IMinerLog
	{
		private readonly String path;

		public FileMinerLog(String path)
		{
			this.path = path;
		}

		public void Append(String level, String contents)
		{
			File.AppendAllText(this.path, DateTime.Now.ToString("o") + " - " + level + ": " + contents + Environment.NewLine);
		}
	}
}
