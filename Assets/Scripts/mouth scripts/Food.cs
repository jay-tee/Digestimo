using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

	public Camera cam;
	private float maxWidth;
	private bool camControl;
	
	
	// Use this for initialization
	void Start () {
		if (cam == null) { 
			cam = Camera.main;
		}
		camControl = false;
		Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
		maxWidth = targetWidth.x;
		
		
	}
	public void ToggleControl (bool toggle){
		camControl = toggle;
	}
	// Update is called once per physics time
	void FixedUpdate () {
		if (camControl) {
			Vector3 rawPosition = cam.ScreenToWorldPoint (Input.mousePosition);
			Vector3 targetPosition = new Vector3 (rawPosition.x, rawPosition.y, 0.0f);
			float targetWidth = Mathf.Clamp (targetPosition.x, -maxWidth, maxWidth);
			targetPosition = new Vector3 (targetWidth, targetPosition.y, targetPosition.z); 
			GetComponent<Rigidbody2D> ().MovePosition (targetPosition);
		}
	}

}
