using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other){
		if ((other.gameObject.tag == "bacteria")||(other.gameObject.tag== "Saliva")) 
				Destroy (other.gameObject);



			
			
	}
}
