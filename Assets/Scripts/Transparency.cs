using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparency : MonoBehaviour {
	// attached to every cell
	

	// private variables set in Start
	private Component[] srs;

	// Use this for initialization
	void Start () {
		srs = GetComponentsInChildren<SpriteRenderer>();

		// change all the sprites in cell assembly to 75% transparency
		foreach (SpriteRenderer sr in srs) {
			sr.color = new Color (1f, 1f, 1f, 0.75f);
		}

	}
}
