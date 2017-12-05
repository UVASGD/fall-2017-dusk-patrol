using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    public static float timeLimit = 3f;
    public static float timeFactor;
    public static float maxCoolDown = 4;

    private float coolDownTimer = 0;
    private float timeTravelTimer = 0;

	public float maxTimeResource = 500f;
    public float timeResource;

	public AudioSource timeBack;

	// Use this for initialization
	void Start () {
		timeResource = maxTimeResource;
		timeBack.volume = OptionScript.loadSettings ().SFX;
	}
	
	// Update is called once per frame
    void Update ()
    {
		if (Input.GetButton ("Fire2")) {
			if (Input.GetButtonDown ("Fire2")) {
				timeBack.Play ();
			}
			if (timeResource > 0.0f) {
				//Debug.Log("Backtracking");
				timeFactor = -1;
				coolDownTimer = 0;
				timeTravelTimer += Time.deltaTime;
				timeResource -= Time.deltaTime;

			} else {
				timeFactor = 0;

			}
		}
        else
        {
			if (timeResource < maxTimeResource) {
				timeResource = timeResource + 0.5f * Time.deltaTime;
			}
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

	public int getTimeFactor(){
		return (int) timeFactor;
	}
}
