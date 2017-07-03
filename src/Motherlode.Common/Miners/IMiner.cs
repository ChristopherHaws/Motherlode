using System;
using System.Diagnostics;
using System.IO;

namespace Motherlode.Common.Miners
{
	public interface IMinerLog
	{
		void Append(String level, String value);
	}

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

	public interface IMiner
	{
		Boolean IsRunning { get; }

		void Start();

		void Stop();
	}

	public abstract class ProcessMiner : IMiner, IDisposable
	{
		private readonly IMinerLog log;
		
		private Process process;

		public Boolean IsRunning => this.process != null;

		public ProcessMiner(IMinerLog log)
		{
			this.log = log;
		}

		public void Dispose()
		{
			this.Stop();
		}

		public void Start()
		{
			if (this.process != null)
			{
				return;
			}

			var info = this.GetStartInfo();

			var startInfo = new ProcessStartInfo(info.ExecutablePath, info.Arguments)
			{
				CreateNoWindow = true,
				UseShellExecute = false,
				RedirectStandardOutput = true,
				RedirectStandardError = true
			};

			this.process = new Process
			{
				StartInfo = startInfo
			};

			this.process.OutputDataReceived += this.CaptureOutput;
			this.process.ErrorDataReceived += this.CaptureError;

			this.process.Start();
			this.process.BeginOutputReadLine();
			this.process.BeginErrorReadLine();
		}

		public abstract ProcessMinerStartInfo GetStartInfo();

		public void Stop()
		{
			this.process?.Kill();
			this.process?.Dispose();
			this.process = null;
		}

		private void CaptureOutput(Object sender, DataReceivedEventArgs e)
		{
			this.log.Append("INFO", e.Data);
		}

		private void CaptureError(Object sender, DataReceivedEventArgs e)
		{
			this.log.Append("ERROR", e.Data);
		}
	}

	public class ProcessMinerStartInfo
	{
		public String ExecutablePath { get; set; }
		public String Arguments { get; set; }
	}
}
