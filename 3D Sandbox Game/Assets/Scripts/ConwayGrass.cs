using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConwayGrass : MonoBehaviour {
	int neighbors = 0;
	public bool random;
	public float renderLatency = .5f;
	public float tickInterval = 2;
	public bool alive = false;
	public Material alivem;
	public Material deadm;

	public bool nextAlive;

	MeshRenderer mr;
	// Use this for initialization
	void Start () {
		mr = GetComponent<MeshRenderer> ();
		if (random)
		alive = Random.Range (0, 2) == 0;
		StartCoroutine (Tick());
	}
	
	// Update is called once per frame
	IEnumerator Tick () {
			while(true){
			neighbors = 0;
			GameObject[] gos = GameObject.FindGameObjectsWithTag ("block");
			foreach (GameObject go in gos) {
				if((go.transform.position == transform.position + new Vector3(1, 0, 0) || go.transform.position == transform.position - new Vector3(1, 0, 0) || go.transform.position == transform.position + new Vector3(0, 0, 1) || go.transform.position == transform.position - new Vector3(0, 0, 1) || go.transform.position == transform.position + new Vector3(1, 0, 1) || go.transform.position == transform.position + new Vector3(1, 0, -1) || go.transform.position == transform.position + new Vector3(-1, 0, 1) || go.transform.position == transform.position + new Vector3(-1, 0, -1))){
					ConwayGrass cg = go.GetComponent<ConwayGrass> ();
					if(cg != null){
						if (cg.alive == true){
					neighbors++;
					//Debug.Log ("neighbor found");
						}
					}
				}
			}

			if (neighbors < 2) {
				nextAlive = false;
			} else if (neighbors > 3) {
				nextAlive = false;
			} else if (neighbors == 3) {
				nextAlive = true;
			}

			yield return new WaitForSeconds (renderLatency);
			alive = nextAlive;

			if (alive) {
				mr.material = alivem;
			
			} else {
				mr.material = deadm;
			}

			yield return new WaitForSeconds (tickInterval);
		}
	}
}
