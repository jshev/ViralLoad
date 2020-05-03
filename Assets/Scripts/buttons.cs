using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour {
	// attached to the body sprite in the Map scene

	// set these variables in Start
	private int lvl;
	private string nextScene;
	private SpriteRenderer sr;

	// set array size to 3 and drag three body level sprite into empty array elements in Inspector
	public Sprite[] maps;

	// Use this for initialization
	void Start () {
		// get sprite renderer of biody sprite
		sr = GetComponent<SpriteRenderer> ();

		// get level from player preferences
		lvl = PlayerPrefs.GetInt ("Level");

		// set body level sprite and next scene depending on which level is set in player preferences
		switch (lvl)
		{
		case 1:
			nextScene = "Scene1";
			sr.sprite = maps [0];
			//Debug.Log ("1");
			break;
		case 2:
			nextScene = "Scene2";
			sr.sprite = maps [1];
			//Debug.Log ("2");
			break;
		case 3:
			nextScene = "Scene3";
			sr.sprite = maps [2];
			//Debug.Log ("3");
			break;
		default:
			nextScene = "Menu";
			sr.sprite = maps [0];
			//Debug.Log ("Default");
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
			// click anywhere to continue to next level scene
			if (Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene (nextScene);
			}
	}
}
