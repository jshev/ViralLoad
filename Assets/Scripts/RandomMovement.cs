using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {
	// attached to miniVirus prefab used in EndLevel scene

	// set variable in Start
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		// on instantiation, move miniVirus in random direction within range of -5 to 5
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = RandomVector(-5f, 5f);
	}

	private Vector2 RandomVector(float min, float max) {
		// makes each prefab move in a random direction based on their velocity
		var x = Random.Range(min, max);
		var y = Random.Range(min, max);
		return new Vector2(x, y);
	}
}
