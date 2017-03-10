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
	public float addForceAmount;
	public float jumpForceAmount;

	bool canJump;

	Rigidbody rb;
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
		foreach (KeyCode k in fowardKeys) {
			if (Input.GetKey (k)) {
				rb.AddRelativeForce (new Vector3(0, 0, addForceAmount));
			}
		}
		foreach (KeyCode k in backKeys) {
			if (Input.GetKey (k)) {
				rb.AddRelativeForce (new Vector3(0, 0, -addForceAmount));
			}
		}
		foreach (KeyCode k in leftKeys) {
			if (Input.GetKey (k)) {
				rb.AddRelativeForce (new Vector3(-addForceAmount, 0, 0));
			}
		}
		foreach (KeyCode k in rightKeys) {
			if (Input.GetKey (k)) {
				rb.AddRelativeForce (new Vector3(addForceAmount, 0, 0));
			}
		}
		if (canJump) {
			foreach (KeyCode k in jumpKeys) {
				if (Input.GetKey (k)) {
					rb.AddRelativeForce (new Vector3 (0, jumpForceAmount, 0));
				}
			}
		}
	}
}
