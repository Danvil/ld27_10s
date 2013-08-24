
public static class Globals
{
	// debug
	public const float GAMETIME = 1000.0f;
	public const float WARMUP_TIME = 0.5f;
	public const float BRAVO_TIME = 2.0f;

	// public const float GAMETIME = 10.0f;
	// public const float WARMUP_TIME = 3.5f;
	// public const float BRAVO_TIME = 1.5f;

	public static int Level = 1;
	public static int LastLevel = 5;

	public static Player Player;
	public static Room Room;
	public static Clock Clock;

	public static bool DebugMode = true;
	
	public static bool ExitReached = false;

	public static bool HasStarted = false;
	public static bool HasEnded = false;
}
