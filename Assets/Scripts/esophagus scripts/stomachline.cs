using UnityEngine;
using System.Collections;

public class stomachline : MonoBehaviour {
	public Player player;
	public int counter;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (this.counter == this.player.food.total_count){
			this.player.esophagus_end(true);
		}
	}
	
	 // increment number passed when a ball reaches the stomach
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Ball"){
			Destroy(coll.gameObject);
			this.counter++;
			this.player.score += 10;
		}
}
}
