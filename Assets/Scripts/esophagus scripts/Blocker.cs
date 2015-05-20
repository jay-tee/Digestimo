using UnityEngine;
using System.Collections;

public class Blocker : MonoBehaviour {
	public Vector3 startPos;
	public TextBlocker textb;

	// Use this for initialization
	void Start () {
		this.startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		 // place in path of balls when blocker is active
		if (this.textb.blocking){
			transform.position = startPos;
		}
		 // clear path of balls when blocker is inactive
		else{
			transform.position = new Vector3(-10000000f, -100000000f);
		}
	}
}
