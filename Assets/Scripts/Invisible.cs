using UnityEngine;
using System.Collections;

public class Invisible : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<MeshRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
