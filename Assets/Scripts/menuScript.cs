using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {
	// attached to Main Camera in Menu scene
	// also attached to Main Camera in END scene, bc a whole script for a menu button method seemed silly

	// Use this for initialization
	void Start () {
		// sets the level player preference to 1 at the start of the game
		PlayerPrefs.SetInt ("Level", 1);
	}

	public void playButton() {
		/// attached to Play button in Menu
		SceneManager.LoadScene ("Map");
	}

	public void menuButton() {
		// attached to Menu button in END
		SceneManager.LoadScene ("Menu");
	}
}
