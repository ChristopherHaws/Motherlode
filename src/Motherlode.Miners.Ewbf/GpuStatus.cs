namespace Motherlode.Miners.Ewbf
{
	public enum GpuStatus
	{
		/// <summary>
		/// GPU launched, but not yet work
		/// </summary>
		Launched = 0,

		/// <summary>
		/// GPU launched, but he prepare to work, for example execute benchmark. 
		/// </summary>
		PreparingForWork = 1,

		/// <summary>
		/// GPU works
		/// </summary>
		Working = 2,

		/// <summary>
		/// GPU stopped, for example, a temperature limit is reached
		/// </summary>
		Stopped = 3
	}
}
