using UnityEngine;
using System.Collections.Generic;

public class BallDropper : MonoBehaviour {
	public GameObject ball;
	public int delay;
	public int elapsed;
	
	public MainFood food;
	
	public Material carb;
	public Material fat;
	public Material protein;
	public Material unset;
	
	// Use this for initialization
	void Start () {
		this.delay = UnityEngine.Random.Range(50, 110);
		this.elapsed = 0;		
	}
	
	// Update is called once per frame
	void Update () {
		elapsed++;
		if (elapsed >= delay){
			createBall();
			this.delay = UnityEngine.Random.Range(80, 160);
			this.elapsed = 0;
		}
	}
	
	public void createBall(){
		if (this.food.nutrients.Count > 0){  // there are balls left to drop
			// select the type and color of ball
			int ntype = UnityEngine.Random.Range(0, this.food.nutrients.Count);
			Material color = this.unset;
			if (this.food.nutrients[ntype] == "carb"){color = carb;}
			else if (this.food.nutrients[ntype] == "fat"){color = fat;}
			else if (this.food.nutrients[ntype] == "protein"){color = protein;}
			// reduce the remaining amount of nutrient
			this.food.nutrient_count[ntype] -= 1;
			// remove nutrients that have all been dropped
			if (this.food.nutrient_count[ntype] <= 0){
				this.food.nutrients.RemoveAt(ntype);
				this.food.nutrient_count.RemoveAt(ntype);
			}
			// create the ball and set the color
			GameObject newBall = (GameObject)Instantiate(ball, transform.position, transform.rotation);
			newBall.GetComponent<MeshRenderer>().material = color;
		}
	}
}
