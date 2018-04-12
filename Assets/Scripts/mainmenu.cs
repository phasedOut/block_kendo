using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour {

	public static bool gameIsSet = false;
	public static string winner;

	void OnGUI() {
		if (gameIsSet) {
			GUI.Box (new Rect (Screen.width/2, (Screen.height/2) - 200, 200, 200), winner + " won!");
				
			if (GUI.Button (new Rect (Screen.width/2, (Screen.height/2), 200, 200), "Play Again")) {
				SceneManager.LoadScene ("Level1");
				gameIsSet = false;
			}
		}
	}
}
