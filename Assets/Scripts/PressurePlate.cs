using UnityEngine;
using System.Collections.Generic;

public class PressurePlate : MonoBehaviour {

	public Material matPressed;

	public List<Trigger> triggers = new List<Trigger>();

	void Start() { }
	
	void Update() { }

	void OnTriggerEnter(Collider other) {
		foreach(Trigger x in triggers) {
			x.OnTrigger();
		}
		this.GetComponentInChildren<Renderer>().material = matPressed;
	}

}
