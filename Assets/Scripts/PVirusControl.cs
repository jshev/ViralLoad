using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PVirusControl : MonoBehaviour
{
	// set these variables in Start
	private float speed;
    private Rigidbody2D playerRBody;
	private Text myText;
	private GameObject dialogue;
	private Text flvrTxt;
	private GameObject closeButton;
	private bool winLose;
	private GameObject[] viruses;
	private bool mutation;
	private int lvl;
	private bool onceCellText;
	private string currentScene;

	// all the objects whose position trigger info pop-up
	private GameObject WBC;
	private GameObject ebola;
	private GameObject flu;
	private GameObject herpes;
	private GameObject platelet;
	private GameObject alveoli;

	// bools to ensure info pop-ups only happen once per level per object
	private bool onceWBC;
	private bool onceEbola;
	private bool onceFlu;
	private bool onceHerpes;
	private bool oncePlatelet;
	private bool onceAlveoli;

    // Use this for initialization
	void Start(){
		viruses = GameObject.FindGameObjectsWithTag("Player");
		myText = GameObject.Find("Text").GetComponent<Text>();
		flvrTxt = GameObject.Find("FlavorText").GetComponent<Text>();
		dialogue = GameObject.Find ("DialogueBox");
		closeButton = GameObject.Find ("CloseButton");
        playerRBody = GetComponent<Rigidbody2D>();
        speed = 25f;
		winLose = false;
		mutation = false;
		onceCellText = false;

		// deactivate pop up dialogue box and button at Start
		// set pop up text to nothing
		closeButton.SetActive(false);
		dialogue.SetActive(false);
		flvrTxt.text = "";

		WBC = GameObject.Find ("WBC Shell VIP");
		ebola = GameObject.Find ("Ebola");
		flu = GameObject.Find ("Flu");
		herpes = GameObject.Find ("Herpes");
		platelet = GameObject.Find ("Platelet VIP");
		alveoli = GameObject.Find ("Alveoli VIP");

		// set all bools to false at Satrt
		onceWBC = false;
		onceEbola = false;
		onceFlu = false;
		onceHerpes = false;
		oncePlatelet = false;
		onceAlveoli = false;

		// get player preferences level
		lvl = PlayerPrefs.GetInt ("Level");

		// set current level, so player restarts current level if they die
		switch (lvl)
		{
		case 1:
			currentScene = "Scene1";
			break;
		case 2:
			currentScene = "Scene3";
			break;
		case 3:
			currentScene = "Scene3";
			break;
		default:
			currentScene = "Menu";
			break;
		}
    }

    // Update is called once per frame
    void Update() {
		// populate array with all gameobjects with Player Tag
		// counts how many virus buddies the player has in the level
		viruses = GameObject.FindGameObjectsWithTag("Player");

		// allows player to move if they haven't won or lost the level yet
		// WASD or arrow keys work for movement
		if (!winLose) {
			playerRBody.MovePosition (playerRBody.position + new Vector2 (Input.GetAxis ("Horizontal") * speed * Time.deltaTime, Input.GetAxis ("Vertical") * speed * Time.deltaTime));
		}

		// bringd the player back to the menu if they press R
		if (Input.GetKey(KeyCode.R)) {
			SceneManager.LoadScene ("Menu");
		}

		// bring up info pop up once and only once if player is within range of these objects
		// WBCs are in every level, so info changes every level to stay fresh
		if (WBC != null) {
			if (Vector2.Distance (transform.position, WBC.transform.position) < 28f && !onceWBC) {
				onceWBC = true;
				Time.timeScale = 0;
				dialogue.SetActive (true);
				switch (lvl)
				{
				case 1:
					flvrTxt.text = "Component of blood whose purpose is to battle viruses, bacteria, and " +
						"other foreign invaders. When a particular area is under attack, WBCs rush in to " +
						"destroy the harmful substance and prevent illness.";
					break;
				case 2:
					flvrTxt.text = "A higher-than-normal WBC count usually indicates some type of infection, " +
						"as white blood cells are multiplying to destroy an enemy, such as a bacteria or virus.";
					break;
				case 3:
					flvrTxt.text = "Illnesses such as HIV/AIDS can weaken the immunity systems by rapidly " +
						"destroying WBCs and leave the host vulnerable to more inflections…";
					break;
				default:
					flvrTxt.text = "Component of blood whose purpose is to battle viruses, bacteria, and " +
						"other foreign invaders. When a particular area is under attack, WBCs rush in to " +
						"destroy the harmful substance and prevent illness.";
					break;
				}
				closeButton.SetActive (true);
			}
		}
		if (ebola != null) {
			if (Vector2.Distance (transform.position, ebola.transform.position) < 28f && !onceEbola) {
				onceEbola = true;
				Time.timeScale = 0;
				dialogue.SetActive (true);
				flvrTxt.text = "A rare but deadly virus that damages the immune system and organs" +
					" as it spreads. Ultimately causes levels of platelets in blood to drop. This" +
					" leads to severe, uncontrollable bleeding.";
				closeButton.SetActive (true);
			}
		}
		if (flu != null) {
			if (Vector2.Distance (transform.position, flu.transform.position) < 28f && !onceFlu) {
				onceFlu = true;
				Time.timeScale = 0;
				dialogue.SetActive (true);
				flvrTxt.text = "A common virus that attacks the respiratory system. Not the same as " +
					"stomach \"flu\" that cause diarrhea and vomiting. It usually resolves on its own, " +
					"but its complications can sometimes be deadly.";
				closeButton.SetActive (true);
			}
		}
		if (herpes != null) {
			if (Vector2.Distance (transform.position, herpes.transform.position) < 28f && !onceHerpes) {
				onceHerpes = true;
				Time.timeScale = 0;
				dialogue.SetActive (true);
				flvrTxt.text = "A highly prevalent virus that spreads rapidly through direct contact " +
					"with a person who carries HSV. There are two types: Type 1 is oral HSV and type " +
					"2 is sexual HSV. There is no cure…";
				closeButton.SetActive (true);
			}
		}
		if (platelet != null) {
			if (Vector2.Distance (transform.position, platelet.transform.position) < 28f && !oncePlatelet) {
				oncePlatelet  = true;
				Time.timeScale = 0;
				dialogue.SetActive (true);
				flvrTxt.text = "Component of blood whose function is to react to bleeding from " +
					"blood vessel injury by clumping, thereby initiating a blood clot.";
				closeButton.SetActive (true);
			}
		}
		if (alveoli != null) {
			if (Vector2.Distance (transform.position, alveoli.transform.position) < 28f && !onceAlveoli) {
				onceAlveoli = true;
				Time.timeScale = 0;
				dialogue.SetActive (true);
				flvrTxt.text = "Tiny, balloon-shaped air sacs that sit at the end of the respiratory tree " +
					"and allow the passage of oxygen and carbon dioxide between the lungs and bloodstream.";
				closeButton.SetActive (true);
			}
		}

    }

	void OnCollisionEnter2D(Collision2D collide) {
		if (collide.gameObject.tag == "cell") {
			// if player collides with cell...
			// first give them info pop up to ensure they see the information
			// cells are in every level, so their info changes every level to stay fresh
				if (!onceCellText) {
					Time.timeScale = 0;
					dialogue.SetActive (true);
					switch (lvl)
					{
					case 1:
						flvrTxt.text = "Viruses can infect only certain species of hosts and only certain cells " +
							"within that host. Some viruses, such as rabies, are able to mutate and infect multiple " +
							"kinds of cells.";
						break;
					case 2:
						flvrTxt.text = "A virus attaches to a receptor site on the host cell membrane through " +
							"attachment proteins. This can be illustrated by thinking of several keys and several " +
							"locks, where each key will fit only one specific lock.";
						break;
					case 3:
						flvrTxt.text = "Viruses depend on the host cells that they infect to reproduce. Once a " +
							"virus has been engulfed by a cell, new viruses are formed, self-assemble, and burst" +
							" out of the host cell and going on to infect other cells.";
						break;
					default:
						flvrTxt.text = "Viruses can infect only certain species of hosts and only certain cells " +
							"within that host. Some viruses, such as rabies, are able to mutate and infect multiple " +
							"kinds of cells.";
						break;
					}
					closeButton.SetActive (true);
					onceCellText = true;
			} else {
				// if player has the mutation, they can move on to the mini game
				if (mutation) {
					PlayerPrefs.SetInt ("Level", (lvl + 1));
					Debug.Log (PlayerPrefs.GetInt ("Level"));
					SceneManager.LoadScene ("Mini");
				}
			}
		} else if (collide.gameObject.tag == "wbc") {
			if (viruses.Length == 1) {
				// if there is only one gameobject left with the Player tag...
				// player has no buddies to sacrifice and must restart level
				winLose = true;
				myText.text = "Virus Eradicated";
				Invoke ("reload", 1f);
				Debug.Log ("Collided with wbc");
			} else {
				// if player has a buddy to sacrifice...
				// destroy first buddy in player object
				// destroy WBC and Text Mesh attached to WBC
				// to prevent floating WBHITE BLOOD CELL text from continuing to chase the player
				Destroy (transform.GetChild (0).gameObject);
				Destroy (collide.gameObject.transform.parent.transform.GetChild (1).gameObject);
				Destroy (collide.gameObject);
			}
		} else if (collide.gameObject.tag == "dna") {
			// if player collides with DNA...
			// destriy DNA and set mutation to true so player can move on to mini game
			Destroy (collide.gameObject);
			mutation = true;
		}
	}

	void reload() {
		// Invoked on Game Over
		SceneManager.LoadScene (currentScene);
	}

	public void unpause() {
		// attach to close info pop up button
		Time.timeScale = 1;
		dialogue.SetActive(false);
		flvrTxt.text = "";
		closeButton.SetActive(false);
	}
}
