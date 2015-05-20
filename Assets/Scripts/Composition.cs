using UnityEngine;
using System.Collections;

public class Composition : MonoBehaviour 
{
	// b = breakfast
	public GameObject b_protein_Bar;
	public GameObject b_carb_Bar;
	public GameObject b_fat_Bar;

	// l = lunch
	public GameObject l_protein_Bar;
	public GameObject l_carb_Bar;
	public GameObject l_fat_Bar;

	// d = dinner
	public GameObject d_protein_Bar;
	public GameObject d_carb_Bar;
	public GameObject d_fat_Bar;

	// nutrient amounts based on nutritional value of waffles
	public GameObject breakfast_protein_amount;
	public GameObject breakfast_carb_amount;
	public GameObject breakfast_fat_amount;
	
	// nutrient amounts based on nutritional value of Subway sandwich
	public GameObject lunch_protein_amount;
	public GameObject lunch_carb_amount;
	public GameObject lunch_fat_amount;

	// nutrient amounts based on nutritional value of pizza	
	public GameObject dinner_protein_amount;
	public GameObject dinner_carb_amount;
	public GameObject dinner_fat_amount;

	// y position of the bars
	public float by = 2.2f;
	public float ly = -0.3f;
	public float dy = -2.8f;

	// scaling factor to make all sets of bars same length
		// took total of all nutrient amounts / total length of bar sets
	public float bfit = 2.575f;
	public float lfit = 2.312f;
	public float dfit = 18.706f;

	// Use this for initialization
	void Start () 
	{
		// --s variables in this method correspond to 's'cale
		set_breakfast_bars();
		set_lunch_bars ();
		set_dinner_bars ();
		set_percent_pos ();

	}

	void set_breakfast_bars(){
		float bps = 5.9f / this.bfit;
		float breakfast_protein_position = bps / 2.0f;
		
		float bcs = 24.7f / this.bfit;
		float breakfast_carb_position = ((breakfast_protein_position + bps / 2.0f) + bcs / 2.0f);
		
		float bfs = 10.6f / this.bfit;
		float breakfast_fat_position = ((breakfast_carb_position + bcs / 2.0f) + bfs / 2.0f);
		

		Vector3 temp = b_protein_Bar.transform.position;
		//set protein pos
		temp.x = breakfast_protein_position;
		temp.y = this.by;
		temp.z = 0.0f;
		b_protein_Bar.transform.position = temp;
		//set protein scale
		temp = b_protein_Bar.transform.localScale;
		temp.x = bps;
		temp.y = 1.0f;
		temp.z = 1.0f;
		b_protein_Bar.transform.localScale = temp;

		Vector3 temp1 = b_carb_Bar.transform.position;
		//set carb pos
		temp1 = b_protein_Bar.transform.position;
		temp1.x = breakfast_carb_position;
		//temp1.y = this.by+1;							//OFFSET FOR VISIBILITY!!!!!!!!!!
		b_carb_Bar.transform.position = temp1;
		//set carb scale
		temp1 = b_protein_Bar.transform.localScale;
		temp1.x = bcs;
		b_carb_Bar.transform.localScale = temp1;

		Vector3 temp2 = b_fat_Bar.transform.position;
		// set fat pos
		temp2 = b_protein_Bar.transform.position;
		temp2.x = breakfast_fat_position;
		b_fat_Bar.transform.position = temp2;
		//set fat scale
		temp2 = b_protein_Bar.transform.localScale;
		temp2.x = bfs;
		b_fat_Bar.transform.localScale = temp2;
	}

	void set_lunch_bars(){

		float bps = 18.0f / this.lfit;
		float breakfast_protein_position = bps / 2.0f;
		
		float bcs = 15.0f / this.lfit;
		float breakfast_carb_position = ((breakfast_protein_position + bps / 2.0f) + bcs / 2.0f);
	
		float bfs = 4.0f / this.lfit;
		float breakfast_fat_position = ((breakfast_carb_position + bcs / 2.0f) + bfs / 2.0f);

		// some of the variables above correspond to breakfast, but are used to set lunch by comparison
		Vector3 temp = l_protein_Bar.transform.position;
		//set protein pos
		temp.x = breakfast_protein_position;
		temp.y = this.ly;
		temp.z = 0.0f;
		l_protein_Bar.transform.position = temp;
		//set protein scale
		temp = l_protein_Bar.transform.localScale;
		temp.x = bps;
		temp.y = 1.0f;
		temp.z = 1.0f;
		l_protein_Bar.transform.localScale = temp;
		
		Vector3 temp1 = l_carb_Bar.transform.position;
		//set carb pos
		temp1 = l_protein_Bar.transform.position;
		temp1.x = breakfast_carb_position;
		//temp1.y = this.ly+1;							//OFFSET FOR VISIBILITY!!!!!!!!!!
		l_carb_Bar.transform.position = temp1;
		//set carb scale
		temp1 = l_protein_Bar.transform.localScale;
		temp1.x = bcs;
		l_carb_Bar.transform.localScale = temp1;
		
		Vector3 temp2 = l_fat_Bar.transform.position;
		// set fat pos
		temp2 = l_protein_Bar.transform.position;
		temp2.x = breakfast_fat_position;
		l_fat_Bar.transform.position = temp2;
		//set fat scale
		temp2 = l_protein_Bar.transform.localScale;
		temp2.x = bfs;
		l_fat_Bar.transform.localScale = temp2;
	}

	void set_dinner_bars(){
		float bps = 67.1f / this.dfit;
		float breakfast_protein_position = bps / 2.0f;
		
		float bcs = 145.1f / this.dfit;
		float breakfast_carb_position = ((breakfast_protein_position + bps / 2.0f) + bcs / 2.0f);
		
		float bfs = 87.1f / this.dfit;
		float breakfast_fat_position = ((breakfast_carb_position + bcs / 2.0f) + bfs / 2.0f);
		
		// some of the variables above correspond to breakfast, but are used to set lunch by comparison
		Vector3 temp = d_protein_Bar.transform.position;
		//set protein pos
		temp.x = breakfast_protein_position;
		temp.y = this.dy;
		temp.z = 0.0f;
		d_protein_Bar.transform.position = temp;
		//set protein scale
		temp = d_protein_Bar.transform.localScale;
		temp.x = bps;
		temp.y = 1.0f;
		temp.z = 1.0f;
		d_protein_Bar.transform.localScale = temp;
		
		Vector3 temp1 = d_carb_Bar.transform.position;
		//set carb pos
		temp1 = d_protein_Bar.transform.position;
		temp1.x = breakfast_carb_position;
		//temp1.y = this.dy+1;							//OFFSET FOR VISIBILITY!!!!!!!!!!
		d_carb_Bar.transform.position = temp1;
		//set carb scale
		temp1 = d_protein_Bar.transform.localScale;
		temp1.x = bcs;
		d_carb_Bar.transform.localScale = temp1;
		
		Vector3 temp2 = d_fat_Bar.transform.position;
		// set fat pos
		temp2 = d_protein_Bar.transform.position;
		temp2.x = breakfast_fat_position;
		d_fat_Bar.transform.position = temp2;
		//set fat scale
		temp2 = d_protein_Bar.transform.localScale;
		temp2.x = bfs;
		d_fat_Bar.transform.localScale = temp2;
	}

	void set_percent_pos (){
		breakfast_protein_amount.transform.position = b_protein_Bar.transform.position;
		breakfast_carb_amount.transform.position = b_carb_Bar.transform.position;
		breakfast_fat_amount.transform.position = b_fat_Bar.transform.position;

		lunch_protein_amount.transform.position = l_protein_Bar.transform.position;
		lunch_carb_amount.transform.position = l_carb_Bar.transform.position;
		lunch_fat_amount.transform.position = l_fat_Bar.transform.position;

		dinner_protein_amount.transform.position = d_protein_Bar.transform.position;
		dinner_carb_amount.transform.position = d_carb_Bar.transform.position;
		dinner_fat_amount.transform.position = d_fat_Bar.transform.position;

	}

	// Update is called once per frame
	//void Update () {
	//
	//}
}
