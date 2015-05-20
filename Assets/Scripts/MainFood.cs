using UnityEngine;
using System.Collections.Generic;

public class MainFood : MonoBehaviour 
{
	//private string type;
	//private bool selected = false;
	
	public List<string> nutrients;
	public List<int> nutrient_count;
	
	// change to determine how many particles you want in a level	
	public int total_count = 20;	
	public int particle_min = 6;
	public int particle_max = 8;

	// Use this for initialization
	void Start () 
	{
	
		// currently setup to randomly assign nutrient amounts
		this.nutrients = new List<string>();
		this.nutrients.Add("carb");
		this.nutrients.Add("fat");
		this.nutrients.Add("protein");
		
		this.nutrient_count = new List<int>();
		this.nutrient_count.Add(UnityEngine.Random.Range(particle_min, particle_max));
		this.nutrient_count.Add(UnityEngine.Random.Range(particle_min, particle_max));
		this.nutrient_count.Add(this.total_count - this.nutrient_count[0] - this.nutrient_count[1]);
	}
	
	public List<string> get_nutrients(){return this.nutrients;}
	public List<int> get_nutrient_count(){return this.nutrient_count;}
	
	// type of food can only be selected once then never changed
	//public void select_food(string type){
	//	if (!this.selected){
	//		this.type = type;
	//		this.selected = true;
	//	}
	//}
	
	// Update is called once per frame
	//void Update () {
	//
	//}
}
