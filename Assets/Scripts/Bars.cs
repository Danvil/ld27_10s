using UnityEngine;
using System.Collections;

public class Bars : MonoBehaviour {

	public bool IsLifted { get; private set; }

	public void Lift()
	{
		if(IsLifted) {
			return;
		}
		this.transform.position += new Vector3(0.0f, 2.0f, 0.0f);
	}

	// Use this for initialization
	void Start () {
		IsLifted = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
