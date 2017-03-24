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
	public float addForceAmount;
	public float jumpForceAmount;
	public float sprintForceAmount;

	bool canJump;


	Rigidbody rb;

	EMath emath = new EMath();
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

	}
	
	void OnCollisionEnter(){
		canJump = true;
	}
	void OnCollisionExit(){
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
		if (canJump && rb.velocity.y < jumpForceAmount/1) {
			foreach (KeyCode k in jumpKeys) {
				if (Input.GetKey (k)) {
					rb.AddRelativeForce (new Vector3 (0, jumpForceAmount, 0));

				}
			}
		}
	}
}
