using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneScript : MonoBehaviour {

	public List<State> stateList;
	int timeIndex = 0;

	GameManagerScript gm;

	// Use this for initialization
	void Start () {
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
