using UnityEngine;
using System.Collections;


public class Beaker : MonoBehaviour{

	public LiverController lc;

	public Beaker(){
	}

	void OnMounseDown(){
		lc.setSelected(gameObject);
	}
	// Use this for initialization
	void Start () {

	}


}