using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining : MonoBehaviour {
	public float reach;
	public KeyCode mineKey;
	public Material targeted;
	public Material idle;

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
			if (hit.collider.gameObject.tag == "block" && Input.GetKeyDown (mineKey)) {
				Destroy (hit.collider.gameObject);
			}
			} else {
			lr.SetPosition(1, origin + (Camera.main.transform.forward * reach));
			lr.material = idle;
			lr.enabled = true;

			}


	}
}
