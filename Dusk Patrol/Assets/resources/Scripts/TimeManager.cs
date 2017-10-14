using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	public float timeFactor;
    public float timeResource;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeResource = timeResource + 0.1f;
        if (Input.GetButton ("Fire2")) {
			timeFactor = -1;
            if (timeResource > 0.5f)
            {
                timeResource = timeResource - 0.5f;
            }
            else
            {
                timeResource = 0;
            }
		} else {
			timeFactor = 1;
		}
	}
}
