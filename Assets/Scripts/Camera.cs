using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
	
	public float paddX = 6.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float xmin = Globals.Level.minX + paddX;
		float xmax = Globals.Level.maxX - paddX;
		if(xmax < xmin) {
			xmax = (xmin + xmax) * 0.5f;
			xmin = xmax;
		}
		Vector3 p = this.camera.transform.position;
		p.x = Mathf.Min(Mathf.Max(xmin,Globals.Player.transform.position.x), xmax);
		this.camera.transform.position = p;
	}
}
