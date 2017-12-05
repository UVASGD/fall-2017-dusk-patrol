using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour {

	private AudioSource a;

	// Use this for initialization
	void Start () {
		a = GetComponent<AudioSource> ();
		a.volume = OptionScript.loadSettings ().BGM;
		a.loop = true;
		a.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
