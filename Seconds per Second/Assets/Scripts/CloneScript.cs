using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneScript : MonoBehaviour {

	public List<State> stateList;
	int timeIndex = 0;

	const float TIME_THRESHOLD = 0.02f;

	GameManagerScript gm;

	// Use this for initialization
	void Start () {
		PlayerMovement pm = GameObject.Find ("Player").GetComponent<PlayerMovement> ();
		stateList = new List<State> ();
		for (int i = 0; i < pm.stateList.Count; i++)
		{
			stateList.Add (pm.stateList [i].GetCopy());
		}

		gm = GameObject.Find ("GameManager").GetComponent<GameManagerScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateState ();

		/*
		if (gm.worldTime == stateList [timeIndex].GetStamp() && timeIndex < stateList.Count) {
			transform.position = stateList [timeIndex].GetCoords ();
			timeIndex++;
		}
		*/
	}

	void UpdateState()
	{
		int closestStateIndex = FindClosestStateIndex ();

		if (closestStateIndex == -1)
		{
			GetComponent<SpriteRenderer> ().enabled = false;
		}
		else
		{
			GetComponent<SpriteRenderer> ().enabled = true;
			transform.position = stateList[closestStateIndex].GetCoords();
		}
	}

	int FindClosestStateIndex()
	{
		int closestStateIndex = 0;
		float closestStateDifference = Mathf.Abs(gm.worldTime - stateList[0].GetStamp());

		for (int i = 1; i < stateList.Count; i++)
		{
			float difference = Mathf.Abs (gm.worldTime - stateList [i].GetStamp ());
			if (difference < closestStateDifference)
			{
				closestStateIndex = i;
				closestStateDifference = difference;
			}
		}

		if ((closestStateIndex == 0 || closestStateIndex == stateList.Count - 1) && closestStateDifference > TIME_THRESHOLD)
		{
			return -1;
		}

		return closestStateIndex;
	}
}
