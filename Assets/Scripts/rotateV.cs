using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class rotateV : MonoBehaviour {
	// attached to rotating virus key in Mini Game scene

	// set variables in Start
	private float winningAngle;
	private float possibleWin;
	private int chance;
	private GameObject keyhole;
	private bool winLose;
	private Text myText;
	private Animator myAnimator;

	// set array size to 8 and and drag eight shape sprites into empty array elements in Inspector
	public Sprite[] shapes;


	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator> ();
		// octogon 0, pentagon 1, triganle 2, square 3, trapzoid 4, circle 5, rectangle 6, diamond 7
		chance = Random.Range(1, 7);
		keyhole = GameObject.Find ("Keyhole");
		keyhole.GetComponent<SpriteRenderer> ().sprite = shapes [chance];
		winLose = false;
		myText = GameObject.Find("Text").GetComponent<Text>();

		// 0, -45, -90.00001, -135, -180, 135, 90.00001, 45

		// randomly set keyhole shape
		// set winning angle and possible winning angle (due to technical issues with eulerAngles) based on that shape
		switch (chance) {
		case 0:
			// octogon
			winningAngle = 0f;
			//Debug.Log ("2");
			break;
		case 1:
			// pentagon
			winningAngle = -180f;
			possibleWin = 180f;
			//Debug.Log ("1");
			break;
		case 2:
			// triganle
			winningAngle = -90f;
			possibleWin = 270f;
			//Debug.Log ("3");
			break;
		case 3:
			// square
			winningAngle = 135f;
			//Debug.Log ("4");
			break;
		case 4:
			// trapzoid
			winningAngle = -135f;
			possibleWin = 225f;
			//Debug.Log ("5");
			break;
		case 5:
			// circle
			winningAngle = 90f;
			//Debug.Log ("5");
			break;
		case 6:
			// rectangle
			winningAngle = -45f;
			possibleWin = 315f;
			//Debug.Log ("5");
			break;
		default:
			// diamond
			winningAngle = 45f;
			//Debug.Log ("Default");
			break;
		}
		//Debug.Log ("Win: " + winningAngle);
		//Debug.Log ("Possibility " + possibleWin);
	}
	
	// Update is called once per frame
	void Update () {
		// allow player to rotate virus if they have not won yet
		// movement works for left and right arrow keys and AD keys
		if (!winLose) {
			if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A)) {
				transform.Rotate (0, 0, transform.rotation.eulerAngles.x - 45, Space.Self);
				//Debug.Log ("Current Angle: " + transform.rotation.eulerAngles.z);
			} else if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D)) {
				transform.Rotate (0, 0, transform.rotation.eulerAngles.x + 45, Space.Self);
				//Debug.Log ("Current Angle: " + transform.rotation.eulerAngles.z);
			}
		}

		//Debug.Log (transform.rotation.eulerAngles.z);
		// plays short animation and continues to viral infection scene if player gets right animation
		if (possibleWin != 0f) {
			if ((transform.rotation.eulerAngles.z < winningAngle + 1 && transform.rotation.eulerAngles.z > winningAngle - 1) || (transform.rotation.eulerAngles.z < possibleWin + 1 && transform.rotation.eulerAngles.z > possibleWin - 1)) {
				//Debug.Log ("Chicken dinner!");
				winLose = true;
				myAnimator.SetBool ("win", true);
				myText.text = "Infection Spread";
				Invoke ("loadEndAnimation", 1.75f);
			}
		} else {
			if (transform.rotation.eulerAngles.z < winningAngle + 1 && transform.rotation.eulerAngles.z > winningAngle - 1) {
				//Debug.Log ("Chicken dinner!");
				winLose = true;
				myAnimator.SetBool ("win", true);
				myText.text = "Infection Spread";
				Invoke ("loadEndAnimation", 1.75f);
			}
		}

		// return to Menu if player presses R
		if (Input.GetKey(KeyCode.R)) {
			reload ();
		}

	}

	void reload() {
		SceneManager.LoadScene ("Menu");
	}

	void loadEndAnimation() {
		// Invoked on win
		SceneManager.LoadScene ("EndLevel");
	}
}
