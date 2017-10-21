using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    public static float timeLimit = 1f;
    public static float timeFactor;
    public static float maxCoolDown = 4;

    private float coolDownTimer = 0;
    private float timeTravelTimer = 0;
    private bool onCoolDown = false;

    public float timeResource;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    void Update ()
    {
        timeResource = timeResource + 0.1f;
        if (Input.GetButton("Fire2") && timeTravelTimer < timeLimit)
        {
            //Debug.Log("Backtracking");
            timeFactor = -1;
            coolDownTimer = 0;
            timeTravelTimer += Time.deltaTime;
            if (timeResource > 0.5f)
            {
                timeResource = timeResource - 0.3f;
            }
            else
                timeResource = 0;
        }
        else
        {
            timeFactor = 1;
            //Debug.Log("CoolDown");
            coolDownTimer += Time.deltaTime;
            if (coolDownTimer >= maxCoolDown)
                timeTravelTimer = 0;
		}
	}

	public float getTime(){
		return timeLimit;
	}
}
