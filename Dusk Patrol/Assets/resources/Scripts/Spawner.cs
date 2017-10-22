using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] spawns;

	// Use this for initialization
	void Start () {
		spawn(Random.Range(0,spawns.Length - 1));
	}
	
	// Update is called once per frame
	void Update () {
		if (TimeManager.timeFactor > 0 && Random.value < 0.005) { //Should call once every ~5ish seconds
			spawn(Random.Range(0,spawns.Length - 1));
		}
	}

	void spawn(int type) {
		GameObject prefab = spawns [type];
		int broodSize = Random.Range (1, 4);
		for(int i = 0; i < broodSize; i++) {
			float xPos = Random.value;
			float yPos = (Random.value - 0.5f) / 8;
			Vector2 location = Camera.main.ViewportToWorldPoint (new Vector3 (xPos, yPos + 1.25f, 0));
			Instantiate (prefab, location, transform.rotation);
		}
	}
}
