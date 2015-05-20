using UnityEngine;
using System.Collections;

public class PlayerDisplay : MonoBehaviour {
	public Player player;
	public string type;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.type == "score"){
			this.GetComponent<TextMesh>().text = "Score: " + player.score;
		}
		if (this.type == "health"){
			this.GetComponent<TextMesh>().text = "Health: " + player.health;
		}			
	}
}
