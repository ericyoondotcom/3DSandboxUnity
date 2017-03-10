using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchPos : MonoBehaviour {
	public Transform thingToMatch;
	public bool matchPos;
	public Vector3 posOffset;
	public bool matchRotX = true;
	public bool matchRotY = true;
	public bool matchRotZ = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (matchPos) {
			transform.position = thingToMatch.position;
			transform.position += posOffset;
		}

		Vector3 eulerangles = thingToMatch.rotation.eulerAngles;
		Vector3 myangles = transform.rotation.eulerAngles;
		transform.rotation = Quaternion.Euler (matchRotX ? eulerangles.x : myangles.x, matchRotY ? eulerangles.y : myangles.y, matchRotZ ? eulerangles.z : myangles.z);
	}
}
