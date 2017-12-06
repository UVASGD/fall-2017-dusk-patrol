using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	float score;
	public Text scoreText;

	// Use this for initialization
	void Start () {
		score = 0;
		scoreText.text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		score += (Time.deltaTime * TimeManager.timeFactor);
		if (score < 0) {
			score = 0;
		}
		scoreText.text = ((int) score).ToString();
	}
}
