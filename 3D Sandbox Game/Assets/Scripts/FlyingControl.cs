using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class FlyingControl : MonoBehaviour {
	public bool isFlying;
	public KeyCode jumpKey;
	public float doublePressThresh;

	Rigidbody rb;
	float time;
	// Use this for initialization
	void Start () {
		time = doublePressThresh + 1;
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		time += Time.deltaTime;
		if (Input.GetKeyDown (jumpKey)) {
			if (time < doublePressThresh) {
				isFlying = !isFlying;
			}
			time = 0;

		}
		rb.useGravity = !isFlying;
	}
	void OnCollisionEnter(Collision coll){
		ContactPoint contact = coll.contacts [0];
		if (Vector3.Dot (contact.normal, Vector3.up) > 0.5) {
			isFlying = false;
		}
	}
}
