using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {
	
	/** If triggered this will be true excatly for one Update */
	public bool IsTriggered { get; private set; }
	
	bool wasTriggered = false;
	bool requestTriggered = false;
	
	public void OnTrigger()
	{
		requestTriggered = true;
	}
	
	void Awake() {
		IsTriggered = false;
	}
	
	void Start () {
	
	}
	
	void Update () {
		if(wasTriggered) {
			return;
		}
		if(IsTriggered) {
			IsTriggered = false;
			wasTriggered = true;
			return;
		}
		if(requestTriggered) {
			IsTriggered = true;
		}
	}
}
