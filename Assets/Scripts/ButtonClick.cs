using UnityEngine;
using System.Collections;

public class ButtonClick : MonoBehaviour {

	public int level;

	public void Click()
	{	
		Application.LoadLevel (this.level);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
