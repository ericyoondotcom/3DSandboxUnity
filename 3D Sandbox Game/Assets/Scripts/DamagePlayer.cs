using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {
	public int damage;

	void OnCollisionEnter(Collision coll){
		PlayerHealth ph = coll.gameObject.GetComponent<PlayerHealth> ();
		if (ph == null) {
			return;
		}

		ph.health = ph.health - damage;


	}
}
