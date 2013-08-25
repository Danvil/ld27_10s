using UnityEngine;
using System.Collections;

public class Announcer : MonoBehaviour {
	
	float announceTime;

	void Awake() {
		MyTime.Pause = true;
	}

	void Start () {
		announceTime = Globals.WARMUP_TIME;
	}

	void LoadLevel(int i) {
		Globals.LevelID = i;
		string lvl = string.Format("level_{0:000}", Globals.LevelID);
		Globals.HasStarted = false;
		Globals.HasEnded = false;
		Globals.ExitReached = false;
		Application.LoadLevel(lvl); 
	}
	
	void Update () {
		MyTime.UpdateRealDeltaTime();
		float dt = MyTime.RealDeltaTime;
		if(!Globals.HasStarted) {
			announceTime -= dt;
			if(announceTime <= 0.0f) {
				announceTime = 0.0f;
				guiText.text = "";
				Globals.HasStarted = true;
				MyTime.Pause = false;
			}
			else if(announceTime <= 0.5f) {
				guiText.text = "GO!";
			}
			else {
				guiText.text = string.Format("Get ready {0:0}...", announceTime);
			}
		}
		if(Globals.HasStarted && !Globals.HasEnded) {
			if(!MyTime.Pause) {
				MyTime.GameTime += dt;
			}
			if(Globals.Player.IsDead) {
				Globals.HasEnded = true;
				announceTime = Globals.BRAVO_TIME;
			}
			if(Globals.Clock.TimeOut) {
				Globals.HasEnded = true;
				announceTime = Globals.BRAVO_TIME;
			}
			if(Globals.ExitReached) {
				Globals.HasEnded = true;
				announceTime = Globals.BRAVO_TIME;
			}
		}
		if(Globals.HasEnded) {
			MyTime.Pause = true;
			if(!Globals.ExitReached) {
				announceTime -= dt;
				if(announceTime > 0) {
					if(Globals.Player.IsDead) {
						guiText.text = "... (argh!) ...";
					}
					if(Globals.Clock.TimeOut) {
						guiText.text = "Time over ...";
					}
					if(Input.GetButtonDown("Jump")) {
						announceTime = 0.0f;
					}
				}
				else {
					guiText.text = "Press (jump) to retry the level";
					if(Input.GetButtonDown("Jump")) {
						// repeat level
						LoadLevel(Globals.LevelID); 
					}
				}
			}
			else {
				if(Globals.LevelID == Globals.LastLevelID) {
					guiText.text = "Yeah!\nYou completed all " + Globals.LevelID.ToString() + " levels!";
				}
				else {
					announceTime -= dt;
					if(announceTime > 0) {
						guiText.text = "Bravo!";
						if(Input.GetButtonDown("Jump")) {
							announceTime = 0.0f;
						}
					}
					else {
						guiText.text = "Press (jump) for next level";
						if(Input.GetButtonDown("Jump")) {
							// next level
							LoadLevel(Globals.LevelID + 1);
						}
					}
				}
			}
		}
	}
}
