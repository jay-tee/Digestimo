using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
	public Text scoreText;
	public Text carbText;
	public int salivaValue;
	private int score;
	public int carbValue;
	private int carb;
	// Use this for initialization
	void Start () {
		score = 0;
		carb = 50;
		UpdateScore();
	
	}
	void OnTriggerEnter2D (Collider2D b) {
 	if (b.gameObject.tag == "bacteria") {
			score -= 2;
			UpdateScore ();
		} 
	else if (b.gameObject.tag == "Saliva") {
			score += salivaValue;
			carb -= carbValue;
			UpdateScore ();
		} 
	else if ((b.gameObject.tag == "Lower Jaw Destination") || (b.gameObject.tag == "Upper Jaw Destination"))
			score += salivaValue;
		UpdateScore ();
	}



// Update is called once per frame
	void UpdateScore() {
		scoreText.text = "Score:" + score;
		carbText.text = "Carb:" + carb;
	}
}
