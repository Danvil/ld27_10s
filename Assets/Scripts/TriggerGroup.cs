using UnityEngine;
using System.Collections;

public class TriggerGroup : MonoBehaviour {
	
	Trigger trigger;
	
	// Use this for initialization
	void Start () {
		trigger = GetComponent<Trigger>();
	}
	
	// Update is called once per frame
	void Update () {
		if(trigger.IsTriggered) {
			foreach(Trigger x in GetComponentsInChildren<Trigger>()) {
				x.OnTrigger();
			}
		}
	}
}
