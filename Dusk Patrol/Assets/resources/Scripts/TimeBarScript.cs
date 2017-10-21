using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarScript : MonoBehaviour {
	public TimeManager timeBar;
	public Image content;

	private float fillAmount;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		handleBar ();
	}

	private void handleBar(){
		float currentTime = timeBar.getTime();
		content.fillAmount = currentTime / TimeManager.timeLimit;
	}
}
