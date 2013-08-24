using UnityEngine;
using System.Collections;

public class Bars : MonoBehaviour {
	
	Trigger trigger;
	
	public bool IsLifted { get; private set; }

	public void Lift()
	{
		if(IsLifted) {
			return;
		}
		this.transform.position += new Vector3(0.0f, 2.0f, 0.0f);
	}
	
	void Start() {
		IsLifted = false;
		trigger = GetComponent<Trigger>();
	}
	
	// Update is called once per frame
	void Update() {
		if(trigger.IsTriggered) {
			Lift();
		}
	}
}
