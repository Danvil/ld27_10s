using UnityEngine;

static class MyTime
{

	static bool pause;

	static public bool Pause {
		get {
			return pause;
		}
		set {
			pause = value;
			// Time.timeScale = pause ? 0.0f : 1.0f; // for whatever it's good ...
		}
	}

	static public float DeltaTime {
		get {
			return Pause ? 0.0f : UnityEngine.Time.deltaTime;
		}
	}

	static public float Time { get; set; }

}
