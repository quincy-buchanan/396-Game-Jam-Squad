using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State  {

	float timestamp;
	Vector2 coords;
	//GameObject[] collisions; //might not be necessary
	//bool grounded;

	public State (float timestamp, Vector2 coords)
	{
		this.timestamp = timestamp;
		this.coords = coords;
		//this.collisions = collisions;
		//this.grounded = grounded;
	}

	public float GetStamp()
	{
		return timestamp;
	}

	public Vector2 GetCoords()
	{
		return coords;
	}
}
