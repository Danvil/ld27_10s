using UnityEngine;
using System.Collections.Generic;

public class PressurePlate : MonoBehaviour {

	public List<Bars> bars = new List<Bars>();

	void OnPress() {
		foreach(Bars x in bars) {
			x.Lift();
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log("CLICK");
		OnPress();
	}

}
