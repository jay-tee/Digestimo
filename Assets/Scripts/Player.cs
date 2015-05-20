using System.Collections;
using UnityEngine;
using System;

// currently configured for use with Esophagus stage

public class Player : MonoBehaviour {

    public int health = 100;  //Player's total health
    public MainFood food;   //Food that player selects
    public int score;   //Player score
    //public Object[] gameState;  //PLayer gameState
    public int stageCompleted;  //Last level that has been completed. valu = 0 at game start.
	
	public bool esophagus_active = true;
	
	public GameObject EsophagusWinText;
	public GameObject EsophagusFailText;
	public GameObject win_lose;


	void Start(){
		this.health = 100;
		this.score = 0;
	}
	
	void Update () {
		if (this.health <= 0){
			esophagus_end(false);
		}
	}
	
    void Awake() {
        //DontDestroyOnLoad(transform.gameObject);
    }	
	
	public void esophagus_end(bool win){
		this.esophagus_active = false;
		if (win) {
			//EsophagusWinText.SetActive(true);
			win_lose.GetComponent<TextMesh> ().text = "YOU WIN";
			win_lose.GetComponent<TextMesh> ().color = Color.green;
			win_lose.GetComponent<MeshRenderer> ().enabled = true;
		} 
		else 
		{
			//EsophagusFailText.SetActive(true);
			win_lose.GetComponent<TextMesh> ().text = "YOU LOSE";
			win_lose.GetComponent<TextMesh> ().color = Color.red;
			win_lose.GetComponent<MeshRenderer> ().enabled = true;
		}

		StartCoroutine(Level());
	}

		IEnumerator Level()
		{
		yield return new WaitForSeconds (1f);

		Application.LoadLevel (9);
		}
}

