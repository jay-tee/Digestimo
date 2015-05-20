using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public Camera cam;
	public GameObject[] salivas;
	private float maxWidth;
	public float timeLeft;
	public Text timertext;
	public GameObject endGameText;
	public GameObject restartButton;
	public GameObject splashScreen;
	public GameObject startButton;
	public float Speed;
	public bool Switch = false;
	//private bool check=true;
	//public MovingTeeth movingTeeth;
	//public GameObject teeth;
	private bool playing;
	public Food foodController;

	// Use this for initialization
	void Start () {

		playing = false;
		if (cam == null) { 
			cam = Camera.main;
		}
		
		Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
		maxWidth = targetWidth.x;
		timertext.text = "Time Left:\n" + Mathf.RoundToInt (timeLeft);
	}
	void FixedUpdate() {
		if (playing) {
			timeLeft -= Time.deltaTime;

			if (timeLeft < 0) {
				timeLeft = 0;
			}
			timertext.text = "Time Left:\n" + Mathf.RoundToInt (timeLeft);

		}
	}
		public void StartGame(){
		splashScreen.SetActive (false);
		startButton.SetActive (false);
		foodController.ToggleControl (true);
	//	movingTeeth.ToggleControl (true);
		StartCoroutine (Spawn ());
	//	StartCoroutine (LowerJaw ());
	


	}


	IEnumerator Spawn() {
		yield return new WaitForSeconds (1.0f);
		playing = true;
		while (timeLeft > 0) {
			GameObject saliva = salivas[Random.Range(0,salivas.Length)];
			Vector3 spawnPosition = new Vector3 (Random.Range(-maxWidth,maxWidth), transform.position.y, 0.0f);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate(saliva,spawnPosition,spawnRotation);
		//	Instantiate(teeth);

			yield return new WaitForSeconds (Random.Range (1.0f,2.0f));
		}
		yield return new WaitForSeconds (1.0f);
		endGameText.SetActive (true);
		yield return new WaitForSeconds (1.0f);
		restartButton.SetActive (true);
	}

}
