using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(InputField))]
public class Commands : MonoBehaviour {
	InputField ipf;

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
		default:
			ipf.text = "Command not found";
			break;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
