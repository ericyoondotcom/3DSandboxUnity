using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerHealth))]
public class DeathCheck : MonoBehaviour {
	public GameObject deathMessage;

	PlayerHealth ph;
	// Use this for initialization
	void Start () {
		ph = GetComponent<PlayerHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ph.health <= 0) {
			
			deathMessage.SetActive (true);
			//Time.timeScale = 0;
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
