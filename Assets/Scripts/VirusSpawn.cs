using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VirusSpawn : MonoBehaviour {

	// set variable to miniVirus prefab in Inspector
	public GameObject virusPrefab;

	// set variable in Start
	private int lvl;

	// Use this for initialization
	void Start () {
		// only allow scene to play for three seconds... will crash otherwise
		Invoke ("loadNextScene", 3f);

		// get level from player preferences
		lvl = PlayerPrefs.GetInt ("Level");
	}
	
	// Update is called once per frame
	void Update () {
		// put InvokeRepeating in Update on purpose to get the right effect
		InvokeRepeating("launchVirus", 0f, 0.25f);
		
	}

	void launchVirus() {
		// instantiate new miniViruses from spawner
		GameObject virus = Instantiate(virusPrefab) as GameObject;
		virus.transform.position = transform.position;
	}

	void loadNextScene() {
		// if the player has completed the last level, load END
		// otherwise load Map
		if (lvl <= 3) {
			SceneManager.LoadScene ("Map");
		} else {
			SceneManager.LoadScene ("END");
		}
	}

}
