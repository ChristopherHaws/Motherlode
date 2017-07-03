using System;

namespace Motherlode.Common.Miners
{
	public interface IMinerLog
	{
		void Append(String level, String value);
	}
}
