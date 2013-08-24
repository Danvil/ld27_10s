
public static class Globals
{
	public const float GAMETIME = 1000.0f;
	public const float WARMUP_TIME = 0.5f; // 3.5f;

	public static Player Player;
	public static Room Room;
	public static Clock Clock;

	public static bool DebugMode = true;
	
	public static bool ExitReached = false;

	public static bool HasStarted = false;
	public static bool HasEnded = false;
}
