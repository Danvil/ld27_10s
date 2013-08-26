using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	const int JUMP_PREPARE = 6;
	const int JUMP_ACCEL = 3;
	
	public float breakMult = 0.1f;
	public float speedMin = 0.2f;
	public float speedMax = 6.0f;
	public float accelerationMove = 300.0f;
	public float accelerationJump = 1.9f;
	public float rotLerpSpeed = 0.4f;

	public bool IsGrounded = false;
	
	public Vector3 gravity = new Vector3(0.0f, -9.81f, 0.0f);
	
	CharacterController controller;
	
	Animation anim;
	
	Vector3 velocity;

	int hasJumped = 0;
	int hasPaused = 0;
	string currentAnim = "Idle";

	public bool IsDead { get; private set; }
	
	public void Die() {
		IsDead = true;
	}

	void Awake() {
		Globals.Player = this;
		controller = GetComponent<CharacterController>();
		anim = GetComponentInChildren<Animation>();
		IsDead = false;
	}
	
	void Start () {
		currentAnim = "Idle";
		anim.CrossFade(currentAnim);
		anim["Jump"].speed = 1.8f;
	}
	
	void Update () {
		// float dtf = 0.02f;
		float dtf = MyTime.DeltaTime;
		// check if player is on ground
		// IsGrounded = controller.isGrounded; // does not work reliably...
		// Color col;
		// if(IsGrounded) {
		// 	col = Color.blue;
		// }
		// else {
		// 	col = Color.green;
		// }
		// foreach(var r in this.GetComponentsInChildren<Renderer>()) {
		// 	r.material.color = col;
		// }
		// move player
		if(!MyTime.Pause) {
			// jump accelerate
			if(IsGrounded && hasJumped <= 0 && Input.GetButtonDown("Jump")) {
				Debug.Log("JUMP");
				hasJumped = JUMP_PREPARE + JUMP_ACCEL;
			}
			if(0 < hasJumped && hasJumped <= JUMP_ACCEL) {
				velocity += new Vector3(0.0f, accelerationJump, 0.0f);
			}
			// adjust speed
			if(IsGrounded) {
				// break over time
				velocity.x *= breakMult;
				velocity.z *= breakMult;
				// move accelerate
				Vector3 movedir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
				float len = movedir.magnitude;
				if(len > 0.0f) {
					velocity += accelerationMove * movedir / len * dtf;
				}
				// limit velocity
				float q = Mathf.Sqrt(velocity.x*velocity.x + velocity.z*velocity.z);
				if(q > speedMax) {
					velocity.x *= speedMax/q;
					velocity.z *= speedMax/q;
				}
			}
			// gravity and collision with ground
			velocity += gravity * dtf;
			if(IsGrounded && velocity.y < 0.0f) {
				velocity.y = 0.0f;
			}
			// set rotation
			float speed = Mathf.Sqrt(velocity.x*velocity.x + velocity.z*velocity.z);
			if(speed > speedMin) {
				float theta = Mathf.Atan2(velocity.z, velocity.x);
				Quaternion target = Quaternion.AngleAxis(-360.0f/(2.0f*Mathf.PI)*theta, new Vector3(0,1,0));
				this.transform.localRotation = Quaternion.Lerp(this.transform.localRotation, target, rotLerpSpeed);
			}
			// play animation
			if(hasJumped > 0) {
				if(currentAnim != "Jump") {
					currentAnim = "Jump";
					anim.CrossFade(currentAnim, 0.1f);
				}
			}
			else {
				if(!IsGrounded) {
					if(currentAnim != "Jump") {
						currentAnim = "Jump";
						anim.CrossFade(currentAnim, 0.4f);
					}
				}
				else {
					if(speed > speedMin) {
						if(currentAnim != "Run") {
							currentAnim = "Run";
							anim.CrossFade(currentAnim, 0.3f);
						}
						anim["Run"].speed = 0.25f*speed;
					}
					else {
						if(currentAnim != "Idle") {
							currentAnim = "Idle";
							anim.CrossFade(currentAnim, 0.1f);
						}
					}
				}
			}
			if(hasJumped <= JUMP_ACCEL) {
				// move controller
				controller.Move(velocity * dtf);
			}
			// jump stuff
			hasJumped --;
			if(hasJumped < 0) hasJumped = 0;
		}
		// check fall to death
		if(this.transform.position.y <= -3.0f) {
			// DIE
			IsDead = true;
		}
		// // go to pause mode
		// if(Globals.HasStarted) {
		// 	if(hasPaused <= 0 && Input.GetButtonDown("Fire1")) {
		// 		MyTime.Pause = !MyTime.Pause;
		// 		hasPaused = 3;
		// 	}
		// 	else {
		// 		hasPaused --;
		// 		if(hasPaused < 0) hasPaused = 0;
		// 	}
		// }
	}
}
