using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {
	
	float timeGone = Globals.GAMETIME;

	public bool TimeOut {
		get { return timeGone <= 0.0f; }
	}

	Color findColor() {
		if(timeGone < 0.1f*Globals.GAMETIME) return Color.red;
		else if(timeGone < 0.3f*Globals.GAMETIME) return Color.yellow;
		else return Color.white;
	}
	
	void Awake() {
		Globals.Clock = this;
	}

	void Start () {
		guiText.pixelOffset = new Vector2(0.0f, 0.5f*Screen.height);
	}
	
	void Update () {
		if(!MyTime.Pause && !Globals.HasEnded) {
			timeGone -= MyTime.DeltaTime;
			timeGone = Mathf.Max(0.0f, timeGone);
			guiText.material.color = findColor();
		}
		float q = 0.01f*Mathf.Round(100.0f*timeGone);
		guiText.text = string.Format("{0:0.00} seconds", q);
	}
}
