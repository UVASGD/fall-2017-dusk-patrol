using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneMovement : MonoBehaviour {

	public Stack<Vector2> future_positions, past_positions;

	float spawnTime;


	// Use this for initialization
	void Start () {
		future_positions = new Stack<Vector2> ();
		past_positions = new Stack<Vector2> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (TimeManager.timeFactor > 0) {
			past_positions.Push (gameObject.transform.position);
			if (future_positions.Count > 0) {
				gameObject.transform.position = future_positions.Pop ();
			}
		} else if (TimeManager.timeFactor < 0) {
			future_positions.Push (gameObject.transform.position);
			if (past_positions.Count > 0) {
				gameObject.transform.position = past_positions.Pop ();
			}
		} else {
			//Don't fucking move i swear to the lord
		}
	}
}
