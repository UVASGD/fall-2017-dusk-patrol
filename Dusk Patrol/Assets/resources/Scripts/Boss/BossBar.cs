using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour {

	public BossHealth hpBar;
	public Image content;

	public GameObject fullBar;

	private float fillAmount;

	// Use this for initialization
	void Start () {
		fullBar.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		handleBar ();
	}

	private void handleBar(){
		float currentHp = hpBar.getHealth ();
		content.fillAmount = currentHp / hpBar.maxHealth;
	}

	public void turnOn() {
		fullBar.SetActive (true);
	}
}
