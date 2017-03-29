using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockoHealthoMeter : MonoBehaviour {
	public float health;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Debug.Log ("Gudbai cruel world! -" + gameObject.name + " (it was deleted)");
			Destroy (gameObject);
		}
			
	}
}
