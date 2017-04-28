using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreeperExplode : MonoBehaviour {
	public Transform player;
	public float range;
	public float fusePerDelta;
	public List<GameObject> inRad;
	// Use this for initialization
	void Start () {
		inRad = new List<GameObject>();
	}
	void OnTriggerEnter(Collider coll){
		if (!inRad.Contains (coll.gameObject) && coll.gameObject.tag == "block") {
			inRad.Add (coll.gameObject);
		}
	}
	void OnTriggerExit(Collider coll){
		if(inRad.Contains(coll.gameObject)){
			inRad.Remove(coll.gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, player.position) < range) {
			transform.parent.localScale = new Vector3 (transform.parent.localScale.x, transform.parent.localScale.y - (Time.deltaTime * fusePerDelta), transform.parent.localScale.z);

		}

		if (transform.parent.localScale.y <= 0) {
			//Debug.Log ("playurr in raing");
			player.SendMessage("explosion",transform.position);
			foreach (GameObject go in inRad) {
				Debug.Log ("destroyed " + go);
				Destroy (go);


			}
			Destroy (transform.parent.gameObject);
		}
	}
}
