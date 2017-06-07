using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour {
	//linear eqns!
	public float slope;
	public float yIntercept;

	float initY;
	PlayerHealth ph;
	// Use this for initialization
	void Start () {
		initY = transform.position.y;
		ph = GetComponent<PlayerHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision coll){
		//Debug.Log ("collided");
		float distance = initY - transform.position.y;
		//Debug.Log (distance);
		if (distance > 0) {
			float damage = (slope * distance) + yIntercept;
			if (damage > 0) {
				ph.health -= (int)damage;
			}
		}
		initY = transform.position.y;
	}
}
