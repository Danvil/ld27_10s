using UnityEngine;
using System.Collections;

public class Bootstrap : MonoBehaviour {
	
	public GameObject pfAnnouncer;
	public GameObject pfClock;
	public GameObject pfCamera;
	
	void Awake() {
		// relevant create game objects
		((GameObject)Instantiate(pfAnnouncer)).transform.parent = this.transform;
		((GameObject)Instantiate(pfClock)).transform.parent = this.transform;
		((GameObject)Instantiate(pfCamera)).transform.parent = this.transform;
	}
	
	void Start () {
	
	}
	
	void Update () {
	
	}
}
