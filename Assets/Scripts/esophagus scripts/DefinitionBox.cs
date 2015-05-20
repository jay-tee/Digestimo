using UnityEngine;
using System.Collections;

public class DefinitionBox : MonoBehaviour {
	public WordBank bank;
	public string text;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<TextMesh>().text = text;
	}
	
	public void UpdateText(string word){
		this.text = this.textWrap(word + ": " + bank.bank[word]);
	}
	
		// Thanks to: http://answers.unity3d.com/questions/223906/textmesh-wordwrap.html
	public string textWrap(string text){
		string builder = "";
		this.GetComponent<TextMesh>().text = "";
		float rowLimit = 4.0f; //find the sweet spot    
		string[] parts = text.Split(' ');
		 // check if each word fits on line
		for (int i = 0; i < parts.Length; i++){
			this.GetComponent<TextMesh>().text += parts[i] + " ";
			 // if it doesn't start a new line
			if (this.GetComponent<Renderer>().bounds.extents.x > rowLimit){
				this.GetComponent<TextMesh>().text = builder.TrimEnd() + System.Environment.NewLine + parts[i] + " ";
			}
			builder = this.GetComponent<TextMesh>().text;
		}
		return builder;
	}
}
