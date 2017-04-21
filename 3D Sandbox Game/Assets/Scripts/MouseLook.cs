using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	public float sensitivityX;
	public float sensitivityY;
	public float yMin;
	public float yMax;
	float rotationY = 0F;
	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F1)) {
			Debug.Log ("Locking mouse.");
			Cursor.lockState = CursorLockMode.Locked;
		}

		float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

		rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
		rotationY = Mathf.Clamp (rotationY, yMin, yMax);

		transform.rotation = Quaternion.Euler (new Vector3 (-rotationY, rotationX, 0));
	}
}
