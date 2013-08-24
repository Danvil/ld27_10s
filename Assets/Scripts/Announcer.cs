using UnityEngine;
using System.Collections;

public class Announcer : MonoBehaviour {
	
	float dt;

	void Awake() {
		MyTime.Pause = true;
	}

	void Start () {
		dt = 3.5f;
	}
	
	void Update () {
		if(!Globals.HasStarted) {
			Debug.Log(Time.deltaTime);
			dt -= Time.deltaTime;
			if(dt <= 0.0f) {
				dt = 0.0f;
				guiText.text = "";
				Globals.HasStarted = true;
				MyTime.Pause = false;
			}
			else if(dt <= 0.5f) {
				guiText.text = "GO!";
			}
			else {
				guiText.text = string.Format("Get ready {0:0}...", dt);
			}
		}
		if(Globals.HasStarted && !Globals.HasEnded) {
			if(!MyTime.Pause) {
				MyTime.Time += Time.deltaTime;
			}
			if(Globals.Player.IsDead) {
				Globals.HasEnded = true;
			}
			if(Globals.Clock.TimeOut) {
				Globals.HasEnded = true;
			}
		}
		if(Globals.HasEnded) {
			MyTime.Pause = true;
			if(Globals.Player.IsDead) {
				guiText.text = "You died ...";
			}
			if(Globals.Clock.TimeOut) {
				guiText.text = "Time over ...";
			}
		}
	}
}
