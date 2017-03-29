using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockoHealthoMeter : MonoBehaviour {
	public float health;
	public float regen;
	float initHealth;
	MeshRenderer mr;
	// Use this for initialization
	void Start () {
		mr = GetComponent < MeshRenderer> ();
		initHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
		mr.material.color = new Color (initHealth / health, 1, 1);
		if (health <= 0) {
			Debug.Log ("Gudbai cruel world! -" + gameObject.name + " (it was deleted)");
			Destroy (gameObject);
		}
		if (health < initHealth) {
			health += regen * Time.deltaTime;

		}
		if (health > initHealth) {
			health = initHealth;
		}
			
	}
}
