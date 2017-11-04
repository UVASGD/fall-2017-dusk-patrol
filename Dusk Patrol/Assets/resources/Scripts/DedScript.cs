using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DedScript : MonoBehaviour {

	public Button button;

	// Use this for initialization
	void Start () {
		button.onClick.AddListener (() => OnClick ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnClick() {
		SceneManager.LoadScene (0);
	}
}
