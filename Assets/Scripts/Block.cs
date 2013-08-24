using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	
	public float wobbleDuration = 10.0f;
	public float wobbleAplitude = 0.05f;
	
	public float baseHeight;
	public float basePhase;
	
	// Use this for initialization
	void Start () {
		baseHeight = -0.05f + 0.1f*Random.value;
		basePhase = Random.value;
	}
	
	// Update is called once per frame
	void Update () {
		
		float h = Mathf.Sin((MyTime.time / wobbleDuration + basePhase) * (2.0f * Mathf.PI));
		this.transform.localPosition = this.transform.localPosition.ChangeY(baseHeight + wobbleAplitude*h);
	}
}
