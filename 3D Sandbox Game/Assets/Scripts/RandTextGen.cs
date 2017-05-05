using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;

public class RandTextGen : MonoBehaviour {
	public Text t;
	public List<string> disps;

	// Use this for initialization
	void Start () {
		StreamReader reader = new StreamReader ("Assets/mcsplashes.txt");

		while (!reader.EndOfStream) {
			disps.Add(reader.ReadLine());
				
		}
			
		t.text = disps[Random.Range (0, disps.Count)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
