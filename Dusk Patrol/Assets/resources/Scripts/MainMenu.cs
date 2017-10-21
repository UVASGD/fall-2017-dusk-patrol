using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    Button startButton;

    void Awake()
    {
        startButton = (Button)GameObject.Find("StartButton").GetComponent<Button>();
        startButton.onClick.AddListener(() => OnClick());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnClick()
    {
        SceneManager.LoadScene("Main");
    }
}
