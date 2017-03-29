using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : MonoBehaviour {
	public float reach;
	public int mineKey;
	public int placeKey;
	public Material targeted;
	public Material idle;
	public float mineDamage;

	LineRenderer lr;
	// Use this for initialization
	void Start () {
		lr = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
			
			lr.SetPosition (0, transform.position);
			Vector3 origin = Camera.main.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));
			RaycastHit hit;
		if (Physics.Raycast (origin, Camera.main.transform.forward, out hit, reach)) { //"out" makes the variable "exported" back. so if you set val inside method the var gets set. reference, not value
			
			lr.SetPosition (1, hit.point);
			lr.material = targeted;
			lr.enabled = true;	
			if (hit.collider.gameObject.tag == "block" && Input.GetMouseButton (mineKey)) {
				BlockoHealthoMeter bhm = hit.collider.gameObject.GetComponent<BlockoHealthoMeter> ();
				bhm.health -= mineDamage * Time.deltaTime;
			} else if (hit.collider.gameObject.tag == "block" && Input.GetMouseButtonDown (placeKey)) {
				
				Vector3 shift;
				if (Vector3.Dot (hit.normal, Vector3.up) > 0.5) {
					shift = Vector3.up;
				} else if (Vector3.Dot (hit.normal, Vector3.down) > 0.5) {
					shift = Vector3.down;
				} else if (Vector3.Dot (hit.normal, Vector3.left) > 0.5) {
					shift = Vector3.left;
				} else if (Vector3.Dot (hit.normal, Vector3.right) > 0.5) {
					shift = Vector3.right;
				} else if (Vector3.Dot (hit.normal, Vector3.forward) > 0.5) {
					shift = Vector3.forward;
				} else if (Vector3.Dot (hit.normal, Vector3.back) > 0.5) {
					shift = Vector3.back;
				} else {
					shift = Vector3.zero;
					Debug.Log ("The zombie apocalypse is happening!");

				}
				GameObject n = (GameObject)Instantiate (hit.collider.gameObject, hit.collider.transform.position + shift, hit.collider.transform.rotation);
				//we're not using "n" but i might need it later

			
			} 
		}else {
			lr.SetPosition (1, origin + (Camera.main.transform.forward * reach));
			lr.material = idle;
			lr.enabled = true;

		}


	}
}
