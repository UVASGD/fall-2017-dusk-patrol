using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DethScoreScript : MonoBehaviour {

	public float dethScore;
	public Text scoreText;

	// Use this for initialization
	void Start () {
		dethScore = ScoreScript.score;
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = ((int) dethScore).ToString();
	}
}
