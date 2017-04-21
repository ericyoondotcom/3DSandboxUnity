using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour {
	public int damage;
	public float damageSpeed = 0.7f;
	bool attack = true;


	void OnCollisionStay(Collision coll){
		if (attack != true) {
			return;
		}
		StartCoroutine (HurtCycle ());
		PlayerHealth ph = coll.gameObject.GetComponent<PlayerHealth> ();
		if (ph == null) {
			return;
		}

		ph.health = ph.health - damage;


	}

	IEnumerator HurtCycle(){
		attack = false;
			yield return new WaitForSeconds (damageSpeed);
		attack = true;
	}



}
