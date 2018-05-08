using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneScript : MonoBehaviour {

	List<State> stateList;
	int timeIndex = 0;

	GameManagerScript gm;

	// Use this for initialization
	void Start () {
		stateList = GameObject.Find ("Player").GetComponent<PlayerMovement> ().stateList;
		gm = GameObject.Find ("GameManager").GetComponent<GameManagerScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gm.worldTime == stateList [timeIndex].GetStamp() && timeIndex < stateList.Count) {
			transform.position = stateList [timeIndex].GetCoords ();
			timeIndex++;
		}
	}
}
