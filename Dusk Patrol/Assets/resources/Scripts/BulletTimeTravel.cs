using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTimeTravel : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
        float pos = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        float timefactor = FindObjectOfType<TimeManager>().timeFactor;
        if (timefactor == -1) // Object is moving back in time
        {
            
        }
	}
}
