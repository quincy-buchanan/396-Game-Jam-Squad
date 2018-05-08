using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rb;
	GameObject gameManager;

	float playerSpeed = 5f;

	List<State> stateList;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		gameManager = GameObject.Find ("GameManager");
		stateList = new List<State>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameManager.GetComponent<GameManagerScript> ().paused)
		{
			CheckMovement ();
			AddState ();
		}
	}

	void CheckMovement()
	{
		int xDir = 0;

		if (Input.GetKey (KeyCode.A))
			xDir--;
		if (Input.GetKey (KeyCode.D))
			xDir++;

		rb.velocity = new Vector2 (xDir * playerSpeed, rb.velocity.y);



	}

	void AddState()
	{
		stateList.Add (new State (gameManager.GetComponent<GameManagerScript>().worldTime, transform.position));
	}
}
