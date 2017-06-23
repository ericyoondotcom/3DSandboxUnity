using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mining : MonoBehaviour {
	public float reach;
	public int mineKey;
	public int placeKey;
	public Material targeted;
	public Material idle;
	public float mineDamage;
	public List<Material> blockSel;
	public Text matDisp;
	int currMat = 0;

	LineRenderer lr;
	// Use this for initialization
	void Start () {
		lr = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		KeyCode[] kcs = new KeyCode[]{KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.Alpha0};
		if (kcs.Length != blockSel.Count) {
			Debug.LogError ("kcs and blockSel do not have the same length/count!");

		}
		for (int i = 0; i < kcs.Length; i++) {
			if (Input.GetKeyDown (kcs [i])) {
				currMat = i;
			}
		}
		matDisp.text = blockSel [currMat].name;
			lr.SetPosition (0, transform.position);
			Vector3 origin = Camera.main.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));
			RaycastHit hit;
		Debug.Log("raw: " + Input.mousePosition + ", toworld: " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
	//	if (Physics.Raycast (origin, Camera.main.transform.forward, out hit, reach)) { //"out" makes the variable "exported" back. so if you set val inside method the var gets set. reference, not value
		if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, reach)){
			lr.SetPosition (1, hit.point);
			lr.material = targeted;
			lr.enabled = true;	
			if ((hit.collider.gameObject.tag == "block" || hit.collider.gameObject.tag == "npc") && Input.GetMouseButton (mineKey)) {
				BlockoHealthoMeter bhm = hit.collider.gameObject.GetComponent<BlockoHealthoMeter> ();
				bhm.health -= mineDamage * Time.deltaTime;
			} else if ((hit.collider.gameObject.tag == "block"/* || hit.collider.gameObject.tag == "npc"*/) && Input.GetMouseButtonDown (placeKey)) {
				
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
				n.GetComponent<BlockTypes> ().blockType = BlockTypes.blockTypes.unknown;
				MeshRenderer mr = n.GetComponent<MeshRenderer> ();
				mr.material = blockSel [currMat];


			
			} 
		}else {
			//lr.SetPosition (1, origin + (Camera.main.transform.forward * reach));
			/*RaycastHit linehit;
			Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out linehit);
			lr.SetPosition(1, linehit.point);
			lr.material = idle;
			lr.enabled = true;*/

			lr.enabled = false;

		}


	}
}
