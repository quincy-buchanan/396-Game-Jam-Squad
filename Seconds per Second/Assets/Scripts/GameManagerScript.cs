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
		Timer ();
	}

	void Timer()
	{
		if (!paused) {
			worldTime -= Time.deltaTime;
			timer.text = worldTime.ToString ("F1");
		}
	}
}
