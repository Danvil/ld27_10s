using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	public bool isGround = false;
	
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

	bool explode = false;
	
	// Update is called once per frame
	void Update () {
		if(Globals.HasEnded) {
			if(Globals.IsExploded) {
				explode = true;
			}
		}
		else {
			float h = Mathf.Sin((MyTime.GameTime / wobbleDuration + phaseOffset) * (2.0f * Mathf.PI));
			this.transform.localPosition =
				basePosition
				+ offset
				+ wobbleAplitude*h*wobbleDirection;
			if(isGround) {
				Vector3 v = this.transform.localPosition;
				v.y = basePosition.y;
				this.transform.localPosition = v;
			}
		}
	}

	void FixedUpdate() {
		if(explode) {
			explode = false;
			this.rigidbody.isKinematic = false;
			this.rigidbody.constraints = RigidbodyConstraints.None;
			if(Globals.IsFailed) {
				this.rigidbody.AddForce(500.0f*Random.insideUnitSphere);
			}
			else {
				this.rigidbody.AddForce(100.0f* new Vector3(0,-1,0) + 10.0f*Random.insideUnitSphere);
			}
		}
	}
}
