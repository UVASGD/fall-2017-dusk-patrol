using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionScript : MonoBehaviour {

	public Button backButton;
	public Slider BGM, SFX;

	const string filename = "options.dat";

	Options currentSettings;

	// Use this for initialization
	void Start () {
		currentSettings = loadSettings ();
		BGM.normalizedValue = currentSettings.BGM;
		SFX.normalizedValue = currentSettings.SFX;
		backButton.onClick.AddListener (() => backToMain ());
		BGM.onValueChanged.AddListener (delegate {
			updateBGM ();
		});
		SFX.onValueChanged.AddListener (delegate {
			updateSFX ();
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void backToMain() {
		saveSettings (currentSettings);
		SceneManager.LoadScene ("Main Menu");
	}

	void updateBGM() {
		currentSettings.BGM = BGM.normalizedValue;
	}

	void updateSFX() {
		currentSettings.SFX = SFX.normalizedValue;
	}

	bool checkForPreviousOptions() {
		string pathToFile = Application.persistentDataPath + filename;
		return File.Exists (pathToFile);
	}

	static Options loadSettings() {
		string pathToFile = Application.persistentDataPath + filename;
		if (File.Exists (pathToFile)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (pathToFile, FileMode.Open);
			Options o = bf.Deserialize (file) as Options;
			file.Close ();
			return o;
		}
		return new Options (1, 1);
	}

	void saveSettings(Options o) {
		string pathToFile = Application.persistentDataPath + filename;
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (pathToFile);
		bf.Serialize (file, o);
		file.Close ();
	}
}

[Serializable]
public class Options {
	public float BGM;
	public float SFX;

	public Options(float backgroundMusic, float soundEffects) {
		BGM = backgroundMusic; //0 to 1
		SFX = soundEffects; //0 to 1
	}
}
