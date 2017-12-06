using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DedScript : MonoBehaviour {

	public AudioClip omaeWaMoShinderu;
	public Button button;

	// Use this for initialization
	void Start () {
		//AudioSource audio = GetComponent<AudioSource>();
		//audio.Play ();
		AudioSource.PlayClipAtPoint (omaeWaMoShinderu, gameObject.transform.position, OptionScript.loadSettings ().SFX);
		button.onClick.AddListener (() => OnClick ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnClick() {
		SceneManager.LoadScene ("Main Menu");
	}
}
