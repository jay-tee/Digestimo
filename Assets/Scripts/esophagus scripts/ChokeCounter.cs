using UnityEngine;
using System.Collections;

public class ChokeCounter : MonoBehaviour {
	public Player player;
	public bool choking;
	public int timer;
	public bool countdown;
	public int healthrate = 0;
	
	// Use this for initialization
	void Start () {
		this.choking = false;
		this.timer = 120;
		this.countdown = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.esophagus_active){
			// in danger of choking
			if (countdown){
				timer--;
			}
			// been in danger of choking too long
			if (timer <= 0){
				this.choking = true;
			}
			if (choking){
				this.GetComponent<TextMesh>().text = "Choking!";
				this.healthrate++;
				if (this.healthrate >= 10){
					this.player.health -= 1;
					this.healthrate = 0;
				}
			}
			else{
				this.GetComponent<TextMesh>().text = "";;		
			}
		}
	}
	
	 // something has entered the choke area and now has 2 seconds to leave before choking starts
	public void startCountdown(){
		this.countdown = true;
	}
	
	 // the choke area has been cleared so choking stops and timer/countdown reset
	public void stopCountdown(){
		this.countdown = false;
		this.timer = 120;
		this.choking = false;
	}
}
