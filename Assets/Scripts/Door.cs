using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public int x, y, z;
	public int height;
	public int wx, wz;

	void Start () {
	
	}
	
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject == Globals.Player.gameObject) {
			// player reached exit!
			Globals.ExitReached = true;
		}
	}
}
