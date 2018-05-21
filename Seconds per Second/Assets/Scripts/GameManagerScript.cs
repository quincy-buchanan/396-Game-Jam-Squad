using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

	public float worldTime = 60.0f;
	public bool paused = false;

	public Text timer;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		CheckTimeTravel ();
		Timer ();
	}

	void Timer()
	{
		if (!paused) {
			worldTime -= Time.deltaTime;
			timer.text = worldTime.ToString ("F1");
		}
	}

	void CheckTimeTravel()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			paused = true;
			GameObject.Find ("Player").GetComponent<PlayerMovement> ().CreateClone ();
		}
		else if (Input.GetKey(KeyCode.Space))
		{
			worldTime += Time.deltaTime * 2f;
			timer.text = worldTime.ToString ("F1");
		}
		else if (Input.GetKeyUp(KeyCode.Space))
		{
			paused = false;
		}
	}
}
