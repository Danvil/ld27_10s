using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	
	public float wobbleDuration = 10.0f;
	public float wobbleAplitude = 0.05f;

	public Vector3 wobbleDirection;
	
	public Vector3 offset;

	float phaseOffset;
	
	Vector3 basePosition;

	public void SetRandomXZWobbleDirection() {
		while(true) {
			wobbleDirection = Random.insideUnitSphere;
			if(wobbleDirection.x != 0.0f && wobbleDirection.z != 0.0f) {
				wobbleDirection.y = 0.0f;
				wobbleDirection.Normalize();
				return;
			}
		}
	}

	public void SetYWobbleDirection() {
		wobbleDirection = new Vector3(0,1,0);
	}

	// Use this for initialization
	void Start () {
		basePosition = this.transform.localPosition;
		phaseOffset = Random.value;
	}
	
	// Update is called once per frame
	void Update () {
		
		float h = Mathf.Sin((MyTime.GameTime / wobbleDuration + phaseOffset) * (2.0f * Mathf.PI));
		this.transform.localPosition =
			basePosition
			+ offset
			+ wobbleAplitude*h*wobbleDirection;
	}
}
