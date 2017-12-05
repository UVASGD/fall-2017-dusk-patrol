using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScrollingBackground : MonoBehaviour
{
	public float scrollSpeed;
	public float tileSizeY;
	public TimeManager timeScript;

	private Vector2 startPosition;

	void Start ()
	{
		timeScript = FindObjectOfType<TimeManager> ();
		startPosition = transform.position;
	}

	void Update ()
	{
		int timeFactor = timeScript.getTimeFactor ();
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);

		// it has to be this way. why? because c# is being annoying.
		Vector3 newpos = transform.position = startPosition + Vector2.up * newPosition;
		newpos.z += 60.0f;	// Arbitrary value mostly, but MUST BE POSITIVE!
		transform.position = newpos;

		if (timeFactor == -1) {
			float newPositionII = Mathf.Repeat(Time.time * -scrollSpeed, tileSizeY);
			Vector3 newpost = transform.position = startPosition + Vector2.up * newPositionII;
			newpost.z += 60.0f;	// Arbitrary value mostly, but MUST BE POSITIVE!
			transform.position = newpost;		
		}
	}
}