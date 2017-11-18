using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScrollingBackground : MonoBehaviour
{
	public float scrollSpeed;
	public float tileSizeY;

	private Vector2 startPosition;

	void Start ()
	{
		startPosition = transform.position;
	}

	void Update ()
	{
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeY);

		// it has to be this way. why? because c# is being annoying.
		Vector3 newpos = transform.position = startPosition + Vector2.up * newPosition;
		newpos.z += 60.0f;
		transform.position = newpos;
	}
}