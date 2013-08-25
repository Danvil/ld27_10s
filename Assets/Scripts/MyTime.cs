using UnityEngine;

static class MyTime
{

	static bool pause;
	
	static float lastTime;

	static public void UpdateRealDeltaTime() {
		float t = RealTime;
		RealDeltaTime = t - lastTime;
		lastTime = t;
	}

	static public float RealTime {
		get {
			return Time.realtimeSinceStartup;
		}
	}
	
	static public float RealDeltaTime { get; private set; }

	static public bool Pause {
		get {
			return pause;
		}
		set {
			pause = value;
			Time.timeScale = pause ? 0.0f : 1.0f; // for whatever it's good ...
		}
	}

	static public float DeltaTime {
		get {
			return Pause ? 0.0f : UnityEngine.Time.deltaTime;
		}
	}
	
	static public float GameTime { get; set; }

}
