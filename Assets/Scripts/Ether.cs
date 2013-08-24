using UnityEngine;
using System.Collections;

public class Ether : MonoBehaviour {
	
	public Material matSolid;
	
	Trigger trigger;
	
	void Start() {
		trigger = GetComponent<Trigger>();
	}
	
	void Update() {
		if(trigger.IsTriggered) {
			// un-ether
			this.collider.enabled = true;
			this.renderer.material = matSolid;
		}
	}
}
