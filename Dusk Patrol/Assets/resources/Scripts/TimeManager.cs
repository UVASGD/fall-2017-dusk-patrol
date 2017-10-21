using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	public static float timeLimit = 3;
	public static float timeFactor;
    public static float maxCoolDown = 10;

    private float coolDownTimer = 0;
    private float timeTravelTimer = 0;
    private bool onCoolDown = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetButton ("Fire2") && timeTravelTimer < timeLimit)
        {
            //Debug.Log("Backtracking");
			timeFactor = -1;
            coolDownTimer = 0;
            timeTravelTimer += Time.deltaTime;
		}
        else
        {
            //Debug.Log("CoolDown");
            coolDownTimer += Time.deltaTime;
            if (coolDownTimer >= maxCoolDown)
                timeTravelTimer = 0;
			timeFactor = 1;
		}
	}

	public float getTime(){
		return timeLimit;
	}
}
