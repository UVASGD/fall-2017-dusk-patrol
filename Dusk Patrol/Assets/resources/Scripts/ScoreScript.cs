using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	int score;
	public Text scoreText;

	// Use this for initialization
	void Start () {
		score = 0;
		scoreText.text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		score++;
		scoreText.text = score.ToString ();
	}
}
