using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysLook : MonoBehaviour {
	public Transform target;
	public bool onlyY;
	public float jumpHeight;

	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (target);
		if (onlyY)
			transform.rotation = Quaternion.Euler (new Vector3(0, transform.rotation.eulerAngles.y, 0));
	}
	void OnCollisionEnter(Collision coll){
		ContactPoint contact = coll.contacts [0];
		if (!(Vector3.Dot (contact.normal, Vector3.up) > 0.5 || Vector3.Dot (contact.normal, Vector3.down) > 0.5)) {
			rb.AddForce (0, jumpHeight, 0);
		}
	}
}
