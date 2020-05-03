using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBCspawn : MonoBehaviour {
	// attached to empty objects named Cell Spawner # in Level 1

	// set cellPrefab to RBC prefab in Inspector
	public GameObject cellPrefab;

	// set variable in Start
	private float secsBetweenLaunch;

	// Use this for initialization
	void Start () {
		// based on the name, different spawners will have different launch times
		// this will ensure the spawner aren't constantly spawning walls of RBCs the player cannot maneuver around
		// don't need to make a separate script for each spawner this way
		switch (gameObject.name)
		{
		case "Cell Spawner 1":
			secsBetweenLaunch = 2f;
			//Debug.Log ("1");
			break;
		case "Cell Spawner 2":
			secsBetweenLaunch = 3f;
			//Debug.Log ("2");
			break;
		case "Cell Spawner 3":
			secsBetweenLaunch = 4f;
			//Debug.Log ("3");
			break;
		case "Cell Spawner 4":
			secsBetweenLaunch = 3f;
			//Debug.Log ("4");
			break;
		case "Cell Spawner 5":
			secsBetweenLaunch = 1f;
			//Debug.Log ("5");
			break;
		default:
			secsBetweenLaunch = 2f;
			//Debug.Log ("Default");
			break;
		}

		// launch another RBC every secsBetweenLaunch seconds, starting at Start
		InvokeRepeating("launchRBC", 0f, secsBetweenLaunch);

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void launchRBC() {
		// instantiate new cells from spawner
		GameObject cell = Instantiate(cellPrefab) as GameObject;
		cell.transform.position = transform.position;
	}

}
