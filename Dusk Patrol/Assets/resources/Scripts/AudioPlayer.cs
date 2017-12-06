using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour {

	public AudioSource mainMusic;
	public AudioSource bossMusic;

	// Use this for initialization
	void Start () {
		bossMusic.loop = true;
		bossMusic.volume = OptionScript.loadSettings ().BGM;
		mainMusic.volume = OptionScript.loadSettings ().BGM;
		mainMusic.loop = true;
		mainMusic.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void goToBoss() {
		mainMusic.Stop ();
		bossMusic.Play ();
	}

	public void goToMain() {
		bossMusic.Stop ();
		mainMusic.Play ();
	}
}
