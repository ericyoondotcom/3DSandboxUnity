using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(RectTransform))]
public class Pulse : MonoBehaviour {

	public float multiply;
	public float top = 25;
	public float startingSize;

	int dir = 1;
	float time;
	RectTransform rt;
	// Use this for initialization
	void Start () {
		rt = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime * dir;
		if (time > top || time < 0) {
			dir *= -1;
		}

		rt.sizeDelta = new Vector2(rt.sizeDelta.x, (time * multiply) + startingSize); 
	}
}
