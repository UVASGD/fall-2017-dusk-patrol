using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    Button startButton;
	Button creditButton;
	Button quitButton;

    void Awake()
    {
        startButton = (Button)GameObject.Find("StartButton").GetComponent<Button>();
        startButton.onClick.AddListener(() => OnClickStart());
		creditButton = (Button)GameObject.Find("CreditButton").GetComponent<Button>();
		creditButton.onClick.AddListener(() => OnClickCredits());
		quitButton = (Button)GameObject.Find ("QuitButton").GetComponent<Button> ();
		quitButton.onClick.AddListener (() => OnClickQuit ());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnClickStart()
    {
        SceneManager.LoadScene("Level 1");
    }
	void OnClickCredits()
	{
		SceneManager.LoadScene("Credit Scene");
	}
	void OnClickQuit()
	{
		Application.Quit ();
	}
}
