using UnityEngine;
#if UNITY_EDITOR
using UnityEditor.Events;
#endif 
using System.Collections;




public class Restart : MonoBehaviour {
	public void RestartGame () {
		Application.LoadLevel (Application.loadedLevel);
}
}