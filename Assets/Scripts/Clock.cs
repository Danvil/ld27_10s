using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {
	
	public float Length = 1000.0f;

	float timeGone = 0.0f;

	public bool TimeOut {
		get { return timeGone >= Length; }
	}

	Color findColor() {
		if(timeGone > 0.9f*Length) return Color.red;
		else if(timeGone > 0.7f*Length) return Color.yellow;
		else return Color.white;
	}
	
	void Awake() {
		Globals.Clock = this;
	}

	void Start () {
		guiText.pixelOffset = new Vector2(0.0f, 0.5f*Screen.height);
	}
	
	void Update () {
		if(!MyTime.Pause) {
			timeGone += MyTime.DeltaTime;
			timeGone = Mathf.Min(Length, timeGone);
			guiText.material.color = findColor();
		}
		float q = 0.01f*Mathf.Round(100.0f*timeGone);
		guiText.text = string.Format("{0:0.00} seconds", q);
	}
}
