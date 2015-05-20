using UnityEngine;
using System.Collections;

public class MovingTeeth : MonoBehaviour {


	public Transform startTransform;
	public Transform endTransform;
	public float Speed;
	public bool Switch = false;
	private bool check=true;
	public void ToggleControl (bool toggle){
		check = toggle;
	}

	void FixedUpdate(){
		if (check) {
			//position of teeth
			if (transform.position == endTransform.position) {
				Switch = true;
			}
		
			if (transform.position == startTransform.position) {
				Switch = false;
			}
			if (Switch) {
				transform.position = Vector3.MoveTowards (transform.position, startTransform.position, Speed);
			} else {
				transform.position = Vector3.MoveTowards (transform.position, endTransform.position, Speed);
			}
		}

	}
}
