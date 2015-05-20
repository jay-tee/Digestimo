using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using System.Xml;


public class IntestineGameController : MonoBehaviour {

	public Camera cam;


	public float timeLeft;
	public Text timertext;
	public GameObject endGameText;
	public GameObject restartButton;
	public GameObject splashScreen;
	public GameObject visibleRestart;
	public Text scoreText;


	public TextAsset xmlAsset;

	public static bool moveFood = false;

	public GameObject puzzleScreen;
	public PuzzleContainer puzzleCollection;



	public GameObject correctAnswer;
	public GameObject wrongAnswer;
	public bool itsCorrectAnswer = false;

	public Text question;
	public Text questionId;
	public Text option1;
	public Text option2;
	public Text option3;
	public Text option4;
	public int puzzleId;
	public int puzzleCounter = 0;
	public int puzzleSize = 0;
	public Puzzle currentPuzzle;
	public int score = 0;
	public int displayedScore = 0;

	public static bool gameOver = false;

	public Button submitButton;


	public Toggle toggle1;
	public Toggle toggle2;
	public Toggle toggle3;
	public Toggle toggle4;
	public Toggle toggle5;


	public bool shouldDisplayPuzzle = false;
	public bool puzzleDisplayed = false;

	public float Speed;
	public bool Switch = false;

	private bool playing;

	private int timeCounter;
	private int delayCounter;


	
	public void Shuffle()
	{
		for (int i = 0; i < puzzleSize; i++)
		{
			int i1 =Random.Range(0,puzzleSize);
			int i2 =Random.Range(0,puzzleSize);

			
			Puzzle temp=puzzleCollection.Puzzles[i1];
			puzzleCollection.Puzzles[i1]=puzzleCollection.Puzzles[i2];
			puzzleCollection.Puzzles[i2]=temp;
		}
	}


	// Use this for initialization
	void Start () {


		XmlDocument xmldoc = new XmlDocument ();

		xmldoc.LoadXml (xmlAsset.text);

		 //puzzleCollection = PuzzleContainer.Load (Path.Combine(Application.dataPath , "Questions/questions.xml"));
		puzzleCollection = PuzzleContainer.LoadXml (xmldoc);
		puzzleSize = puzzleCollection.Puzzles.Count;

		Shuffle ();

	   if( puzzleCounter <puzzleSize){


			DisplayPuzzle();
		}


		playing = false;
		if (cam == null) { 
			cam = Camera.main;
		}

		timertext.text = "Time Left:\n" + Mathf.RoundToInt (timeLeft);
	}


	void DisplayPuzzle(){

		if (puzzleCounter >= puzzleSize) {
			endGameText.GetComponent<Text> ().text = "Sorry, No more questions left";
			endGameText.GetComponent<Text> ().color=Color.blue;
			endGameText.SetActive (true);

			EndGame();
			return;
		}
		currentPuzzle = puzzleCollection.Puzzles[puzzleCounter];
		question.text = currentPuzzle.question;
		questionId.text =currentPuzzle.questionId+"";
		option1.text = currentPuzzle.option1;
		option2.text = currentPuzzle.option2;
		option3.text = currentPuzzle.option3;
		option4.text = currentPuzzle.option4;

		toggle5.isOn = true;

//		toggle1.isOn  = false;
//		toggle2.isOn  = false;
//		toggle3.isOn  = false;
//		toggle4.isOn  = false;


		submitButton.enabled = false;
		puzzleDisplayed = true;
		puzzleCounter++;
		delayCounter = 0;
	}

	public void EvaluateAnswer(){
		timeCounter = 50;
		puzzleScreen.SetActive (false);
		itsCorrectAnswer = false;
		puzzleDisplayed = false;
		if (FindAnswer () == currentPuzzle.correctOption) {
			//correct answer
			correctAnswer.SetActive (true);
			itsCorrectAnswer =true;
			//move the food animation
			score+=100;

			int inverse = (4000/delayCounter);

			score+=inverse;


		} else {
			wrongAnswer.SetActive (true);
		}



	}



	 

	//Function to check which option has been selected
	int FindAnswer(){
		int correct = 0;
		if (toggle1.isOn == true) {
			correct =1;
		}
		else if (toggle2.isOn == true) {
			correct =2;
		}
		else if (toggle3.isOn == true) {
			correct =3;
		}
		else if (toggle4.isOn == true) {
			correct =4;
		}

		return correct;

	}


	public void EnableSubmit(){
		submitButton.enabled = true;
	}

	void FixedUpdate() {
		delayCounter++;
		if (displayedScore < score) {
			displayedScore++;
		}
		scoreText.text = "Score: " +displayedScore ;

		if (playing) {
			timeLeft -= Time.deltaTime;

			if (timeLeft < 0) {
				timeLeft = 0;
			}
			timertext.text = "Time Left:\n" + Mathf.RoundToInt (timeLeft);

		}

		if (moveFood == true) {

			return;
		}


		if (IntestineGameController.gameOver == true) {
			//the player won the game
			endGameText.GetComponent<Text> ().text = "Congrats!, Youw Win";
			endGameText.GetComponent<Text> ().color=Color.green;
			endGameText.SetActive (true);
			EndGame();
			return;
		}


		if (puzzleDisplayed == false) {
			//Debug.Log("The puzzle has not been displayed");
			if (timeCounter > 0) {
				//introducing a wait here
				timeCounter--;
			} else {


				//it was correct answer
				if (itsCorrectAnswer == true){
					moveFood =true;
					wrongAnswer.SetActive (false);
					correctAnswer.SetActive (false);
				}
				else{
					ShowNextPuzzle();
				}


			}

		}

	}

	public void EndGame(){
		wrongAnswer.SetActive (false);
		correctAnswer.SetActive (false);
		puzzleScreen.SetActive (false);
		restartButton.SetActive (true);
		visibleRestart.SetActive (false);
		IntestineGameController.gameOver =false;
	}


	public void ShowNextPuzzle(){
		wrongAnswer.SetActive (false);
		correctAnswer.SetActive (false);
		puzzleScreen.SetActive (true);
		puzzleDisplayed = true;
		DisplayPuzzle ();

	}



	public void StartGame(){
		splashScreen.SetActive (false);
		score = 0;
		displayedScore = 0;
		scoreText.text = "Score: " +displayedScore ;
	
		StartCoroutine (Spawn ());

		puzzleScreen.SetActive (true);
		visibleRestart.SetActive (true);
	


	}


	IEnumerator Spawn() {
		yield return new WaitForSeconds (1.0f);
		playing = true;
		while (timeLeft > 0) {

			yield return new WaitForSeconds (Random.Range (1.0f,2.0f));
		}


		EndGame ();
		yield return new WaitForSeconds (1.0f);
		endGameText.GetComponent<Text> ().text = "Woops!, Game Over";
		endGameText.GetComponent<Text> ().color=Color.red;
		endGameText.SetActive (true);
		yield return new WaitForSeconds (1.0f);
		restartButton.SetActive (true);
		visibleRestart.SetActive (false);
	}

}
