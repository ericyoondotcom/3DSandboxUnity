using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosAndRot : MonoBehaviour {
	public float pos;
	public EMath.dimensions posSetDim;
	public float rot;
	public EMath.dimensions rotSetDim;
	// Use this for initialization

	EMath emath = new EMath();
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = emath.SetOneVector (transform.position, pos, posSetDim);
		transform.rotation = Quaternion.Euler(emath.SetOneVector (transform.rotation.eulerAngles, pos, posSetDim));
	}
}
