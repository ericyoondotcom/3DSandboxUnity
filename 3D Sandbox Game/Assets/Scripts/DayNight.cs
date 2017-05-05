using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour {
	public float totalTime;
	public float maxVal = 3;
	public float currTime;
	 float vel = 1;
	Light l;
	// Use this for initialization
	void Start () {
		l = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		currTime += Time.deltaTime * vel;
		if (currTime >= totalTime || currTime <= 0) {
			vel *= -1;
		}
		l.intensity = (currTime / totalTime) * maxVal;
	}
}
