using UnityEngine;
using System.Collections;

public class PlayerIsGrounded : MonoBehaviour {

	int cnt = 0;
	bool last = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Globals.Player.IsGrounded != last) {
			cnt ++;
			if(cnt == 2) {
				Globals.Player.IsGrounded = last;
			}
		}
		else {
			cnt = 0;
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject != Globals.Player.gameObject) {
				// Debug.Log("OnTriggerEnter");
			last = true;
		}
	}

	void OnTriggerStay(Collider other) {
		if(other.gameObject != Globals.Player.gameObject) {
			last = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject != Globals.Player.gameObject) {
				// Debug.Log("OnTriggerExit");
			last = false;
		}
	}
}
