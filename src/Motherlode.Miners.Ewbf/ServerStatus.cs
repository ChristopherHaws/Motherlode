namespace Motherlode.Miners.Ewbf
{
	public enum ServerStatus
	{
		Error = -1,
		WaitingForConnection = 0,
		Subscribed = 1,
		Authorized = 2,
		Disconnecting = 3
	}
}
