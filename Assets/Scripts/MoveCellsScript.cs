using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCellsScript : MonoBehaviour {
	// attached to RBC prefab

	// set these variables in Start
	private Rigidbody2D rb;
	private Vector2 velocity;

    // Use this for initialization
    void Start () {
		rb = GetComponent<Rigidbody2D>();
		velocity = new Vector2(-40f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		// move position based on velocity and speed
		// MUST be based on Time bc of how the pause mechanic works
		rb.MovePosition(rb.position + velocity * Time.deltaTime);

		// destroy gameobject after 9.5 seconds
		// just enough time to reach the end of the blood vessel
        Destroy(gameObject, 9.5f);
    }
}
