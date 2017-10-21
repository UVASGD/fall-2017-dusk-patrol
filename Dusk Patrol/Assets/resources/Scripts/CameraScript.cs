using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //private static float viewEdgeX;

	void Awake ()
    {
		//Camera.main.aspect = 0.6f;

		Screen.SetResolution (384, 680, false);
        //viewEdgeX = Camera.main.orthographicSize * Screen.width / Screen.height;
    }

    void Update()
    {
        //in case the edges change
        //viewEdgeX = Camera.main.orthographicSize * Screen.width / Screen.height;
		//Screen.SetResolution (384, 680, true);
    }

    public static void WrapAround(GameObject obj)
    {
        //Rigidbody2D rigidbody = obj.GetComponent<Rigidbody2D>();
		Vector3 viewPos = Camera.main.WorldToViewportPoint (obj.transform.position);
		if (viewPos.x > 1)
        {	
			viewPos -= new Vector3 (1, 0, 0);
			obj.transform.position = Camera.main.ViewportToWorldPoint (viewPos);
        }
		if (viewPos.x < 0) {
			viewPos += new Vector3 (1, 0, 0);
			obj.transform.position = Camera.main.ViewportToWorldPoint (viewPos);
		}
    }
}
