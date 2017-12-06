using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
	public Button controlsButton;
	public Button optionButton;
	public Button creditButton;
	public Button quitButton;

	public AudioSource buttonClicker;

    void Awake()
    {
		buttonClicker.volume = OptionScript.loadSettings ().SFX;
        //startButton = (Button)GameObject.Find("StartButton").GetComponent<Button>();
        startButton.onClick.AddListener(() => OnClickStart());
		controlsButton.onClick.AddListener(() => OnClickControls ());
		optionButton.onClick.AddListener (() => OnClickOption ());
		//creditButton = (Button)GameObject.Find("CreditButton").GetComponent<Button>();
		creditButton.onClick.AddListener(() => OnClickCredits());
		//quitButton = (Button)GameObject.Find ("QuitButton").GetComponent<Button> ();
		quitButton.onClick.AddListener (() => OnClickQuit ());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnClickStart()
    {
		buttonClicker.Play ();
        SceneManager.LoadScene("Actual Level 1");
    }
	void OnClickControls()
	{
		buttonClicker.Play ();
		SceneManager.LoadScene("Controls Scene");
	}
	void OnClickOption()
	{
		buttonClicker.Play ();
		SceneManager.LoadScene ("OptionsScreen");
	}
	void OnClickCredits()
	{
		buttonClicker.Play ();
		SceneManager.LoadScene("Credit Scene");
	}
	void OnClickQuit()
	{
		buttonClicker.Play ();
		Application.Quit ();
	}
}
