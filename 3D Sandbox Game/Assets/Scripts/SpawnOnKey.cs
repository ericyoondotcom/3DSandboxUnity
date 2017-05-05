using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnKey : MonoBehaviour {
	public GameObject creeper;
	public GameObject zombbie;
	public Vector3 point = new Vector3(5, 25, 5);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.C)){
			GameObject n = (GameObject)Instantiate (creeper, point, Quaternion.identity);
			n.GetComponent<AlwaysLook> ().target = GameObject.FindGameObjectWithTag ("Person").transform;
			n.GetComponentInChildren<CreeperExplode> ().player = GameObject.FindGameObjectWithTag ("Person").transform;
		}
		if(Input.GetKeyDown(KeyCode.Z)){
			GameObject n = (GameObject)Instantiate (zombbie, point, Quaternion.identity);
			n.GetComponent<AlwaysLook> ().target = GameObject.FindGameObjectWithTag ("Person").transform;

		}
	}
}
