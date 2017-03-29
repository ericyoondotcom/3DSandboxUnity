using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceNoise : MonoBehaviour {
	public int chancePerUpdate;
	public AudioClip ac;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Random.Range (0, chancePerUpdate + 1) == 0) {
			AudioSource.PlayClipAtPoint (ac, transform.position);

		}
	}
}
