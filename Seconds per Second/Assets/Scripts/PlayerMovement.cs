using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rb;
	GameObject gameManager;

	float playerSpeed = 5f;

	List<State> stateList;
	List<GameObject> cloneList;
	public GameObject clonePrefab;

	public LayerMask ground;
	public bool grounded = false;
	float groundedCD = 0f;
	float jumpForce = 500f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		gameManager = GameObject.Find ("GameManager");
		stateList = new List<State>();
		cloneList = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameManager.GetComponent<GameManagerScript> ().paused)
		{
			ToggleFreezePos (false);
			CheckGrounded ();
			CheckMovement ();
			AddState ();
		}
		else{
			ToggleFreezePos (true);
		}
	}

	void ToggleFreezePos(bool isFrozen)
	{
		if (isFrozen)
		{
			rb.constraints = RigidbodyConstraints2D.FreezePosition;
		}
		else{
			rb.constraints = RigidbodyConstraints2D.None;
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

		//jump
		if (Input.GetKeyDown (KeyCode.W) && grounded)
		{
			rb.AddForce (Vector2.up * jumpForce);
			grounded = false;
			groundedCD = 0.2f;
		}

	}

	void CheckGrounded()
	{
		RaycastHit2D rcLeft, rcRight;

		rcLeft = Physics2D.Raycast (new Vector2 (transform.position.x - 0.45f, transform.position.y - 1f), Vector2.down, 0.05f, ground);
		rcRight = Physics2D.Raycast (new Vector2 (transform.position.x + 0.45f, transform.position.y - 1f), Vector2.down, 0.05f, ground);

		if (groundedCD <= 0f)
			groundedCD = 0f;
		else
			groundedCD -= Time.deltaTime;

		if ((rcLeft.transform != null || rcRight.transform != null) && groundedCD == 0f)
		{
			grounded = true;
		}
		else
		{
			grounded = false;
		}
	}

	void AddState()
	{
		stateList.Add (new State (gameManager.GetComponent<GameManagerScript>().worldTime, transform.position));
	}


	public void CreateClone()
	{
		GameObject clone = Instantiate (clonePrefab) as GameObject;
		clone.GetComponent<CloneScript> ().stateList = this.stateList;
		this.stateList.Clear ();
		cloneList.Add (clone);
	}
}
