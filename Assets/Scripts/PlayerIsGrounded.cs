using UnityEngine;
using System.Collections;

public class PlayerIsGrounded : MonoBehaviour {

	int cnt = 0;
	bool last = false;

	int vally = 0;
	bool stayy = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		last = stayy;// stayy || (vally > 0);
		stayy = false;
		if(Globals.Player.IsGrounded != last) {
			cnt ++;
			if(cnt >= 2) {
				Globals.Player.IsGrounded = last;
			}
		}
		else {
			cnt = 0;
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject != Globals.Player.gameObject) {
				Debug.Log("OnTriggerEnter");
			vally ++;
		}
	}

	void OnTriggerStay(Collider other) {
		if(other.gameObject != Globals.Player.gameObject) {
			Debug.Log(other);
				Debug.Log("OnTriggerStay");
			stayy = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject != Globals.Player.gameObject) {
				Debug.Log("OnTriggerExit");
			vally --;
		}
	}
}
