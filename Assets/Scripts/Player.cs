using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float naturalBreak = 1.0f;
	public float speedMax = 3.0f;
	public float acceleration = 0.5f;
	
	public Vector3 gravity = new Vector3(0.0f, -9.81f, 0.0f);
	
	CharacterController controller;
	
	Vector3 velocity;

	public bool IsDead { get; private set; }

	void Awake() {
		Globals.Player = this;
		controller = GetComponent<CharacterController>();
		IsDead = false;
	}
	
	void Start () {
	}
	
	void Update () {
		// move player
		if(!MyTime.Pause) {
			if(controller.isGrounded) {
				// accelerate
				Vector3 movedir = Vector3.zero;
				if(Input.GetKey(KeyCode.A)) {
					movedir += new Vector3(-1,0,0);
				}
				if(Input.GetKey(KeyCode.D)) {
					movedir += new Vector3(+1,0,0);
				}
				if(Input.GetKey(KeyCode.W)) {
					movedir += new Vector3(0,0,+1);
				}
				if(Input.GetKey(KeyCode.S)) {
					movedir += new Vector3(0,0,-1);
				}
				movedir.Normalize();
				velocity += movedir*acceleration;
				// update position
				controller.Move(velocity * MyTime.DeltaTime);
			}
			// break over time
			velocity *= 1.0f - naturalBreak * MyTime.DeltaTime;
			// limit velocity
			float speed = velocity.magnitude;
			if(speed > speedMax) {
				velocity = speedMax*velocity.normalized;
			}
			// compute final velocity
			Vector3 v = velocity;
			// fall down
			if(!controller.isGrounded) {
				v += gravity;
			}
			// move controller
			controller.Move(v * MyTime.DeltaTime);
		}
		// check fall to death
		if(this.transform.position.y <= -3.0f) {
			// DIE
			IsDead = true;
		}
		// go to pause mode
		if(Globals.HasStarted && Input.GetKey(KeyCode.Space)) {
			MyTime.Pause = !MyTime.Pause;
		}
	}
}
