using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public static float viewEdgeX;

	void Awake ()
    {
        viewEdgeX = Camera.main.orthographicSize * Screen.width / Screen.height;
    }

    void Update()
    {
        //in case the edges change
        viewEdgeX = Camera.main.orthographicSize * Screen.width / Screen.height;
    }
}
