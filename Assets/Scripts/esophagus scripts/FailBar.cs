using UnityEngine;
using System.Collections;

public class FailBar : MonoBehaviour {
	public Player player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Ball"){
			this.player.esophagus_end(false);
		}
	}
}
