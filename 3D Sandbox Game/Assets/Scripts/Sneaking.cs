using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider))]
public class Sneaking : MonoBehaviour {
	public KeyCode key;
	public float sneakRadius;
	CapsuleCollider col;

	float initRad;
	// Use this for initialization
	void Start () {
		col = GetComponent<CapsuleCollider> ();
		initRad = col.radius;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (key)) {
			col.radius = sneakRadius;
		} else {
			col.radius = initRad;
		}
	}
}
