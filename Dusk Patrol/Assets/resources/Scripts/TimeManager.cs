using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    public static float timeLimit = 3f;
    public static float timeFactor;
    public static float maxCoolDown = 4;

    private float coolDownTimer = 0;
    private float timeTravelTimer = 0;
    private bool onCoolDown = false;

	public float maxTimeResource = 3f;
    public float timeResource;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    void Update ()
    {
		if (timeResource < maxTimeResource) {
			timeResource = timeResource + 0.1f;
		}
		if (Input.GetButton("Fire2") && timeTravelTimer < timeLimit && timeResource > 0.0f)
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
                timeResource = -0.3f;
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
		return timeResource;
	}
}
