using UnityEngine;
using System.Collections;

public class LiverController : MonoBehaviour {

	public ArrayList selectedList = new ArrayList();
	public bool selected = false;
	public int meter;

	// Use this for initialization
	void Start () {
	
	}

	public void setSelected(GameObject obj){
		if (selectedList.Count >= 2) {
			selectedList = new ArrayList(); 
		}

		selectedList.Add (obj);
	}
	
	// Update is called once per frame
	void Update () {
		foreach(GameObject obj in selectedList){
			Destroy(obj.gameObject);
		}
	}
}
