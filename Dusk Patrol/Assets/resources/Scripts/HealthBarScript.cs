using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {

	public HealthScript hpBar;
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
		float currentHp = hpBar.getHealth ();
		content.fillAmount = currentHp / hpBar.maxHealth;
	}
}
