using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnKey : MonoBehaviour {
	public KeyCode show;
	public KeyCode hide;
	// Use this for initialization
	public GameObject target; //we cant just get the gameobejct because if it's disabled, well, it's disabled
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (show)) {
			target.SetActive (true);
		}
		if (Input.GetKeyDown (hide)) {
			target.SetActive (false);
		}
	}
}
