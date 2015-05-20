using UnityEngine;
using System.Collections;

public class FoodMovementController : MonoBehaviour {

	public Transform start;
	public Transform end;
	public Transform phase1;
	public Transform phase2;
	public Transform phase3;
	public Transform phase4;
	public Transform phase5;
	public IntestineGameController controller;

	
	public float Speed;
	public int step = 0;

	public int stateReached =0;
	public bool Switch = false;


	void  Start () {
		transform.position = Vector3.MoveTowards (transform.position, phase1.position, Speed);
		stateReached =0;

	}


	void UpdatePosition(int state){
		stateReached =state;
		IntestineGameController.moveFood =false;
		controller.ShowNextPuzzle();
	}

	
	void FixedUpdate(){


		if (IntestineGameController.moveFood == false) {
			return;
		}

		if (transform.position == phase1.position) {
			UpdatePosition(1);


		} else if (transform.position == phase2.position) {

			UpdatePosition(2);
		}

		else if (transform.position == phase3.position) {
			UpdatePosition(3);
			
		}

		else if (transform.position == phase4.position) {
			UpdatePosition(4);
			
		}

		else if (transform.position == phase5.position) {
			
			UpdatePosition(5);
		}

		else if (transform.position == start.position) {
			
			UpdatePosition(0);
		}

		else if (transform.position == end.position) {
			IntestineGameController.gameOver = true;
			UpdatePosition(6);
		}



		switch(stateReached){

			case 0:transform.position = Vector3.MoveTowards (transform.position, phase1.position, Speed);
				break;
			case 1:transform.position = Vector3.MoveTowards (transform.position, phase2.position, Speed);
				break;
			case 2:transform.position = Vector3.MoveTowards (transform.position, phase3.position, Speed);
				break;
			case 3:transform.position = Vector3.MoveTowards (transform.position, phase4.position, Speed);
				break;
			case 4:transform.position = Vector3.MoveTowards (transform.position, phase5.position, Speed);
				break;
			case 5:transform.position = Vector3.MoveTowards (transform.position, end.position, Speed);

				break;

			}
			


		
	}

}
