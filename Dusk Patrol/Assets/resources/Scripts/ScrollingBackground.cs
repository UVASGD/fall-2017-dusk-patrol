using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScrollingBackground : MonoBehaviour
{
	public float scrollSpeed;
	public float tileSizeY;
	public TimeManager timeScript;

	void Start ()
	{
		timeScript = FindObjectOfType<TimeManager> ();
	}

	void Update ()
	{
		float increment = scrollSpeed * Time.deltaTime * TimeManager.timeFactor;
		Vector3 currentPosition = gameObject.transform.position;
		currentPosition.y += increment;
		if (currentPosition.y < -1 * tileSizeY) {
			currentPosition.y = tileSizeY;
		}

		if (currentPosition.y > tileSizeY) {
			currentPosition.y = -1 * tileSizeY;
		}
		gameObject.transform.position = currentPosition;
	}
}