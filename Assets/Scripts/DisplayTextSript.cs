using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTextSript : MonoBehaviour {
//The way you set up a popup text to be displayed over a game object is to first attach an empty game object to the sprite.
//Add a mesh renderer and text mesh to the empty child
//type in the text mesh what you want the object to tell the player.
//attach this script to the child and set the distance of when you want the text to be displayed when your player is nearby.
	private Transform player;
    private float showOnDistance;

    MeshRenderer textMesh;
	TextMesh Txt;

    // Use this for initialization
    void Start()
    {
		player = GameObject.Find("Virus Shell").transform;
		showOnDistance = 30f;
        textMesh = gameObject.GetComponent<MeshRenderer>();
		Txt = gameObject.GetComponent<TextMesh>();
        //Gameobject with meshrenderer and text mesh is bing called
    }

    // Update is called once per frame
    void Update()
	{
			//player position is less than 9 or the set showOnDistance
			if (Vector2.Distance (transform.position, player.position) < showOnDistance) {
				textMesh.enabled = true;
			} else {
				textMesh.enabled = false;
				//When the player objects position is within the showOnDistance, the textMesh will display 
				//if player is out of position, text mesh is false and will no longer display.
			}
			//Debug.Log (transform.parent.gameObject.name);
	}
}

