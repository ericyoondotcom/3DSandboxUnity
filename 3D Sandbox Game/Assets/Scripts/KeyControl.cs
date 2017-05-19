using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class KeyControl : MonoBehaviour {
	public List<KeyCode> fowardKeys;
	public List<KeyCode> backKeys;
	public List<KeyCode> leftKeys;
	public List<KeyCode> rightKeys;
	public List<KeyCode> jumpKeys;
	public KeyCode sprintKey;
	public KeyCode downKey;
	public float addForceAmount;
	public float jumpForceAmount;
	public float sprintForceAmount;
	public float flyVerticalForceAmount;

	bool canJump;


	Rigidbody rb;

	EMath emath = new EMath();

	FlyingControl fc;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		fc = GetComponent<FlyingControl> ();
	}
	
	void OnCollisionEnter(Collision coll){
		ContactPoint contact = coll.contacts [0];
		if (Vector3.Dot (contact.normal, Vector3.up) > 0.5) {
			canJump = true;
		}
	}
	void OnCollisionExit(Collision coll){
			canJump = false;
		
	}


	void FixedUpdate () {
		bool moved = false;
		float yvel = rb.velocity.y;
		foreach (KeyCode k in backKeys) {
			if (Input.GetKey (k)) {
				
				rb.velocity = emath.MultiplyVectors(new Vector3(addForceAmount, 0, addForceAmount), -transform.forward);
				moved = true;
			}
		}
		foreach (KeyCode k in leftKeys) {
			if (Input.GetKey (k)) {
				rb.velocity = emath.MultiplyVectors(new Vector3(addForceAmount, 0, addForceAmount), -transform.right);
				moved = true;
			}
		}
		foreach (KeyCode k in rightKeys) {
			if (Input.GetKey (k)) {
				rb.velocity = emath.MultiplyVectors(new Vector3(addForceAmount, 0, addForceAmount), transform.right);
				moved = true;
			}
		}
		foreach (KeyCode k in fowardKeys) {
			if (Input.GetKey (k)) {
				//rb.AddRelativeForce (new Vector3(0, 0, Input.GetKey(sprintKey) ? sprintForceAmount : addForceAmount));
				float vel = (Input.GetKey(sprintKey) ? sprintForceAmount : addForceAmount);
				rb.velocity = emath.MultiplyVectors(new Vector3(vel, 0, vel), transform.forward);
				moved = true;


			}
		}
		rb.velocity = new Vector3 (rb.velocity.x, yvel, rb.velocity.z);
		if (!moved) {
			rb.velocity = emath.MultiplyVectors (rb.velocity, Vector3.up);

		}
		if (canJump/* && rb.velocity.y < jumpForceAmount/1*/) {
			foreach (KeyCode k in jumpKeys) {
				if (Input.GetKey (k)) {
					rb.AddRelativeForce (new Vector3 (0, jumpForceAmount, 0));

				}
			}
		}
		if (fc.isFlying) {
			foreach (KeyCode k in jumpKeys) {
				if (Input.GetKey (k)) {
					rb.AddRelativeForce (new Vector3 (0, flyVerticalForceAmount, 0));

				}
			}
		}
		if (fc.isFlying && Input.GetKey (downKey)) {
			rb.AddRelativeForce (new Vector3 (0, -flyVerticalForceAmount, 0));
		}
	}

	void explosion(Vector3 pos){
		//rb.AddExplosionForce (99, pos, 12);
	}

}
