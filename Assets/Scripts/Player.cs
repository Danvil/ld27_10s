using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float breakLin = 1.0f;
	public float breakQuad = 1.0f;
	public float speedMax = 3.0f;
	public float accelerationMove = 30.0f;
	public float accelerationJump = 100.0f;

	public bool IsGrounded = false;
	
	public Vector3 gravity = new Vector3(0.0f, -9.81f, 0.0f);
	
	CharacterController controller;
	
	Vector3 velocity;

	int hasJumped = 0;
	int hasPaused = 0;

	public bool IsDead { get; private set; }

	void Awake() {
		Globals.Player = this;
		controller = GetComponent<CharacterController>();
		IsDead = false;
	}
	
	void Start () {
	}
	
	void Update () {
		float dtf = MyTime.DeltaTime;
		// check if player is on ground
		// IsGrounded = controller.isGrounded; // does not work reliably...
		if(IsGrounded) {
			this.GetComponentInChildren<Renderer>().material.color = Color.blue;
		}
		else {
			this.GetComponentInChildren<Renderer>().material.color = Color.green;
		}
		// move player
		if(!MyTime.Pause) {
			bool velocity_changed = false;
			// jump accelerate
			if(IsGrounded && hasJumped <= 0 && Input.GetButtonDown("Jump")) {
				Debug.Log("JUMP");
				hasJumped = 3;
			}
			if(hasJumped > 0) {
				velocity += new Vector3(0.0f, accelerationJump, 0.0f);
				velocity_changed = true;
			}
			hasJumped --;
			if(hasJumped < 0) hasJumped = 0;
			// move accelerate
			Vector3 movedir = Vector3.zero;
			if(velocity.y >= 0.0f) {
				movedir += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
				float len = movedir.magnitude;
				if(len > 0.0f) {
					velocity += accelerationMove * movedir / len;
					velocity_changed = true;
				}
			}
			// break over time
			if(IsGrounded && !velocity_changed) {
				Vector3 v = velocity;
				v.y = 0.0f;
				Vector3 breakForce = (breakLin * v + breakQuad * v.magnitude * v) * dtf;
				if(velocity.x < breakForce.x) {
					velocity.x = 0.0f;
				}
				else {
					velocity.x -= breakForce.x;
				}
				if(velocity.z < breakForce.z) {
					velocity.z = 0.0f;
				}
				else {
					velocity.z -= breakForce.z;
				}
			}
			// limit velocity
			float speed = Mathf.Sqrt(velocity.x*velocity.x + velocity.z*velocity.z);
			if(speed > speedMax) {
				velocity.x *= speedMax/speed;
				velocity.z *= speedMax/speed;
			}
			// gravity
			if(!IsGrounded) {
				// Vector3 vold = velocity;
				velocity += gravity * dtf;
				// Debug.Log(vold.ToString() + "->" + velocity.ToString());
			}
			else {
				if(velocity.y < 0.0f) {
					velocity.y = 0.0f;
				}
			}
			// move controller
			controller.Move(velocity * dtf);
		}
		// check fall to death
		if(this.transform.position.y <= -3.0f) {
			// DIE
			IsDead = true;
		}
		// go to pause mode
		if(Globals.HasStarted) {
			if(hasPaused <= 0 && Input.GetButtonDown("Fire1")) {
				MyTime.Pause = !MyTime.Pause;
				hasPaused = 3;
			}
			else {
				hasPaused --;
				if(hasPaused < 0) hasPaused = 0;
			}
		}
	}
}
