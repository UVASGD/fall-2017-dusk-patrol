using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsScript : MonoBehaviour {

	Button back;

	// Use this for initialization
	void Start () {
		back = (Button)GameObject.Find ("BackButton").GetComponent<Button> ();
		back.onClick.AddListener (() => OnClick ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnClick() {
		SceneManager.LoadScene (0);
	}
}
