using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	
	public float wobbleDuration = 10.0f;
	public float wobbleAplitude = 0.05f;
	
	public Vector3 basePosition;

	public Vector3 offset;

	public float phaseOffset;
	
	// Use this for initialization
	void Start () {
		offset = new Vector3(
			-0.05f + 0.1f*Random.value,
			-0.05f + 0.1f*Random.value,
			-0.05f + 0.1f*Random.value);
		phaseOffset = Random.value;
	}
	
	// Update is called once per frame
	void Update () {
		
		float h = Mathf.Sin((MyTime.time / wobbleDuration + phaseOffset) * (2.0f * Mathf.PI));
		this.transform.localPosition =
			basePosition
			+ offset
			+ new Vector3(0, wobbleAplitude*h, 0);
	}
}
