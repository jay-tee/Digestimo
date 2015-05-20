using UnityEngine;
using System;
using System.Collections;
using System.Text;

public class EsophagusInput : MonoBehaviour {
	public string input = "";
	public TextBlocker first;
	public TextBlocker second;
	public TextBlocker third;
	public DefinitionBox definition;
	public Player player;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.player.esophagus_active){
		 // consider catching ArgumentOutOfRange exception for non ascii symbols
	    foreach (char c in Input.inputString) {
             // backspace
			if (c == "\b"[0]){
				//remove last character
				StringBuilder bksp = new StringBuilder(input);
				bksp.Remove(bksp.Length-1, 1);
				input = bksp.ToString();
			}
			 // enter word
			else if (c == "\n"[0] || c == "\r"[0]){
				 // check if word matches any blockers
				if (string.Equals(input, first.text, StringComparison.CurrentCultureIgnoreCase)){
					first.blocking = false;
					definition.UpdateText(first.text);
				}
				if (string.Equals(input, second.text, StringComparison.CurrentCultureIgnoreCase)){
					second.blocking = false;
					definition.UpdateText(second.text);
				}
				if (string.Equals(input, third.text, StringComparison.CurrentCultureIgnoreCase)){
					third.blocking = false;
					definition.UpdateText(third.text);
				}
				 // clear input
				this.input = "";
			}
			 // add to input string
			else{
				this.input += Input.inputString;
			}
		}
	this.GetComponent<TextMesh>().text = this.input;
	}
	}
}
