using System;

namespace Motherlode.Common.Miners
{

	public interface IMiner
	{
		Boolean IsRunning { get; }

		void Start();

		void Stop();
	}
}
