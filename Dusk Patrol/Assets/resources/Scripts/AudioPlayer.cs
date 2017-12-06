using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour {

	public AudioSource mainMusic;
	public AudioSource bossMusic;

	float volume;

	bool isBoss;

	float relmain, relboss;

	// Use this for initialization
	void Start () {
		volume = OptionScript.loadSettings ().BGM;
		bossMusic.loop = true;
		bossMusic.volume = 0;
		mainMusic.volume = volume;
		mainMusic.loop = true;
		mainMusic.Play ();
		relmain = 1;
		relboss = 0;
		isBoss = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isBoss) {
			//Crossfade towards boss
			relboss = Mathf.Min(relboss + Time.deltaTime * 0.5f, 1);
			relmain = 1 - relboss;
		} else {
			//Crossfade towards main
			relmain = Mathf.Min(relmain + Time.deltaTime * 0.5f, 1);
			relboss = 1 - relmain;
		}
		mainMusic.volume = relmain * volume;
		bossMusic.volume = relboss * volume;
	}

	public void goToBoss() {
		isBoss = true;
	}

	public void goToMain() {
		isBoss = false;
	}
}
