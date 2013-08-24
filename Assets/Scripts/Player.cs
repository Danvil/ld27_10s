using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 0.1f;

	void Start () {
	
	}
	
	void Update () {
		Vector3 movedir = Vector3.zero;
		if(Input.GetKey(KeyCode.A)) {
			movedir += new Vector3(-1,0,0);
		}
		if(Input.GetKey(KeyCode.D)) {
			movedir += new Vector3(+1,0,0);
		}
		if(Input.GetKey(KeyCode.W)) {
			movedir += new Vector3(0,0,+1);
		}
		if(Input.GetKey(KeyCode.S)) {
			movedir += new Vector3(0,0,-1);
		}
		this.transform.position += speed * movedir;
	}
}
