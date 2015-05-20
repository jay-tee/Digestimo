using UnityEngine;
using System.Collections;

public class SplashScreenDelayed : MonoBehaviour 
{
	public float delayTime = 5;
	public int level;

	IEnumerator Start()
	{
		yield return new WaitForSeconds (delayTime);

		Application.LoadLevel (this.level);
	}
}
