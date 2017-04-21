using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWhenOutOfRange : MonoBehaviour {
	Transform person;
	public float thresh = 12;
	Collider c;
	BlockoHealthoMeter bhm;
	// Use this for initialization
	void Start () {
		person = GameObject.FindGameObjectWithTag ("Person").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (person.position, transform.position) < 12) {
			c.enabled = true;
			bhm.enabled = true;
		} else {
			c.enabled = false;
			bhm.enabled = false;
		}
	}

}
