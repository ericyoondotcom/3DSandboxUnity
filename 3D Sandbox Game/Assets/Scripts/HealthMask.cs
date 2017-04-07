using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMask : MonoBehaviour {
	public float maxWidth;
	public PlayerHealth player;
	public float posx;
	EMath emath = new EMath();
	RectTransform rt;

	// Use this for initialization
	void Start () {
		rt = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		rt.sizeDelta = new Vector2(emath.DenominateFrac (player.health, player.maxHealth, maxWidth), rt.sizeDelta.y);
		rt.anchoredPosition = new Vector2 (posx - (emath.DenominateFrac (player.health, player.maxHealth, maxWidth) / 2), rt.anchoredPosition.y);
	}
}
