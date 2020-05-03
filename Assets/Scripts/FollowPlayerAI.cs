using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerAI : MonoBehaviour {
	// attached to WBC enemies

	// set variables in Start
	private Transform playerPos;
	private float speed;
	private float max;


	// Use this for initialization
	void Start () {
		playerPos = GameObject.Find("Virus Shell").transform;
		speed = 0f;
		max = 50f;
	}
	
	// Update is called once per frame
	void Update () {
		// find player position based on player object name in Inspector
		playerPos = GameObject.Find("Virus Shell").transform;

		// if player is within range, move towards them...
		// otherise, do not move
		// changing speed variable allows WBC to start and stop
		if ((Mathf.Abs (transform.position.x - playerPos.position.x) < max) && (Mathf.Abs (transform.position.y - playerPos.position.y) < max)) {
			speed = 12f;
		} else {
			speed = 0f;
		}
		transform.position = Vector2.MoveTowards (transform.position, playerPos.position, 
			(float)(speed * Time.deltaTime));
			
	}
}
