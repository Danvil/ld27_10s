using UnityEngine;
using System.Collections;

public class Bootstrap : MonoBehaviour {
	
	public GameObject pfAnnouncer;
	public GameObject pfClock;
	public GameObject pfCamera;
	
	void Awake() {
		// create relevant game objects

		((GameObject)Instantiate(pfAnnouncer)).transform.parent = this.transform;

		((GameObject)Instantiate(pfClock)).transform.parent = this.transform;

		Globals.Level = GameObject.Find("Level").GetComponent<Level>();

		if(GameObject.Find("Main Camera") == null) {
			GameObject go = (GameObject)Instantiate(pfCamera);
			go.transform.parent = this.transform;
			go.camera.backgroundColor = Globals.Level.Background;
		}
	}
	
	void Start () {
	
	}
	
	void Update () {
	
	}
}
