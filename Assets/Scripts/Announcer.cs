using UnityEngine;
using System.Collections;

public class Announcer : MonoBehaviour {
	
	float dt;

	void Awake() {
		MyTime.Pause = true;
	}

	void Start () {
		dt = Globals.WARMUP_TIME;
	}
	
	void Update () {
		if(!Globals.HasStarted) {
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
				dt = Globals.BRAVO_TIME;
			}
			if(Globals.Clock.TimeOut) {
				Globals.HasEnded = true;
				dt = Globals.BRAVO_TIME;
			}
			if(Globals.ExitReached) {
				Globals.HasEnded = true;
				dt = Globals.BRAVO_TIME;
			}
		}
		if(Globals.HasEnded) {
			MyTime.Pause = true;
			if(!Globals.ExitReached) {
				dt -= Time.deltaTime;
				if(dt > 0) {
					if(Globals.Player.IsDead) {
						guiText.text = "... (argh!) ...";
					}
					if(Globals.Clock.TimeOut) {
						guiText.text = "Time over ...";
					}
					if(Input.GetButtonDown("Jump")) {
						dt = 0.0f;
					}
				}
				else {
					guiText.text = "Press JUMP to retry the level";
					if(Input.GetButtonDown("Jump")) {
						// repeat level
						string lvl = string.Format("level_{0:000}", Globals.Level);
						Globals.HasStarted = false;
						Globals.HasEnded = false;
						Globals.ExitReached = false;
						Application.LoadLevel(lvl); 
					}
				}
			}
			else {
				if(Globals.Level == Globals.LastLevel) {
					guiText.text = "Yeah!\nYou completed all " + Globals.Level.ToString() + " levels!";
				}
				else {
					dt -= Time.deltaTime;
					if(dt > 0) {
						guiText.text = "Bravo!";
						if(Input.GetButtonDown("Jump")) {
							dt = 0.0f;
						}
					}
					else {
						guiText.text = "Press JUMP for next level";
						if(Input.GetButtonDown("Jump")) {
							// next level
							Globals.Level ++;
							string lvl = string.Format("level_{0:000}", Globals.Level);
							Globals.HasStarted = false;
							Globals.HasEnded = false;
							Globals.ExitReached = false;
							Application.LoadLevel(lvl); 
						}
					}
				}
			}
		}
	}
}
