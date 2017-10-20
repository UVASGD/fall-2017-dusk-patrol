using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	public float timeLimit = 3;
	public float timeFactor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire2")) {
			timeFactor = -1;
		} else {
			timeFactor = 1;
		}
	}

	public float getTime(){
		return timeLimit;
	}
}
