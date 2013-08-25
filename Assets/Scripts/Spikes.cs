using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour {

	void Start() {
	
	}
	
	void Update() {
	
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject == Globals.Player.gameObject) {
			Globals.Player.Die();
		}
	}
}
