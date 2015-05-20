using UnityEngine;
using System.Collections;

public class chokeline : MonoBehaviour {
	public ChokeCounter counter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	 // notify counter when something could be triggering a choke
	void OnTriggerEnter2D(Collider2D other) {
		this.counter.startCountdown();
    }
	
	 // notify counter whenever anything leaves the choking area
	void OnTriggerExit2D(Collider2D other) {
		 // only stop the countdown when no other balls are in choking area
		if (!this.GetComponent<Collider2D>().IsTouchingLayers()){
			this.counter.stopCountdown();
		}
	}	
}
