using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    Button startButton;
	Button creditButton;

    void Awake()
    {
        startButton = (Button)GameObject.Find("StartButton").GetComponent<Button>();
        startButton.onClick.AddListener(() => OnClick());
		creditButton = (Button)GameObject.Find("CreditButton").GetComponent<Button>();
		creditButton.onClick.AddListener(() => OnClickI());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnClick()
    {
        SceneManager.LoadScene("Level 1");
    }
	void OnClickI()
	{
		SceneManager.LoadScene("Credit Scene");
	}
}
