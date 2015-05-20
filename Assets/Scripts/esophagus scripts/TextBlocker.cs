using UnityEngine;
using System.Collections;

public class TextBlocker : MonoBehaviour {
	public WordBank bank;
	public string text;
	
	public bool blocking = true;
	public int timer = 180;

	// Use this for initialization
	void Start () {
		this.text = this.bank.RandomWord();
		this.GetComponent<TextMesh>().text = this.text;
		}
	
	// Update is called once per frame
	void Update () {
		if (!this.blocking){
			this.timer--;
			  // make text yellow to show unblocked
			this.GetComponent<TextMesh>().color = new Color(1.0f, 1.0f, 0.0f, 1.0f);
		}
		if (this.timer <= 0){
			 // reset timer, blocking, new word, and color when timer is done
			this.timer = 180;
			this.blocking = true;
			this.text = this.bank.RandomWord();
			this.GetComponent<TextMesh>().text = text;
			this.GetComponent<TextMesh>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}
	
	}
}
