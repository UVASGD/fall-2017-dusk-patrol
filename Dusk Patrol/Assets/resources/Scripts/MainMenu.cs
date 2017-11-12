using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
	public Button creditButton;
	public Button quitButton;

	public AudioSource buttonClicker;

    void Awake()
    {
		buttonClicker.volume = OptionScript.loadSettings ().SFX;
        //startButton = (Button)GameObject.Find("StartButton").GetComponent<Button>();
        startButton.onClick.AddListener(() => OnClickStart());
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
        SceneManager.LoadScene("Level 1");
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
