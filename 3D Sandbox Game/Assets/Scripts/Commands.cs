using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(InputField))]
public class Commands : MonoBehaviour {
	InputField ipf;
	public List<BlockTypes.blockTypes> xrayReplacmentBlockTypes;
	// Use this for initialization
	void Start () {
		ipf = GetComponent<InputField> ();
	}


	public void EnterCommand(){
		string text = ipf.text;
		char[] chars = { ' ' };
		List<string> parameters = new List<string> (text.Split(chars));
		switch (parameters [0]) {
		case "":
			break;
			case "/hi":
			case "/hello":
				ipf.text = "Hey! What's up?";
				break;
		case "/bye":
		case "/goodbye":
			ipf.text = "Goodbye!";
			break;
		case "/xray":
			int destroyCount = 0;
			//very expensive!!
			foreach (GameObject go in GameObject.FindGameObjectsWithTag("block")) {
				bool replaceMe = false;
				BlockTypes.blockTypes realbtype = go.GetComponent<BlockTypes> ().blockType;
				foreach (BlockTypes.blockTypes btype in xrayReplacmentBlockTypes) {
					if (realbtype == btype) {
						replaceMe = true;
						break;
					}
				}
				if (!replaceMe) {
					continue;
				}
				destroyCount++;
				Destroy (go);
			}
			ipf.text = "Destroyed " + destroyCount.ToString() + " blocks";
			break;
		default:
			ipf.text = "Command not found";
			break;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
