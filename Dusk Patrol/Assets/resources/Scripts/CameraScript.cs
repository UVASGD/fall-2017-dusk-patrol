using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private static float viewEdgeX;

	void Awake ()
    {
        viewEdgeX = Camera.main.orthographicSize * Screen.width / Screen.height;
    }

    void Update()
    {
        //in case the edges change
        viewEdgeX = Camera.main.orthographicSize * Screen.width / Screen.height;
    }

    public static void WrapAround(GameObject obj)
    {
        Rigidbody2D rigidbody = obj.GetComponent<Rigidbody2D>();
        if (Mathf.Abs(obj.transform.position.x) > CameraScript.viewEdgeX)
        {
            //so that the planes don't keep jumping back and forth
            if (Mathf.Sign(rigidbody.velocity.x) == Mathf.Sign(obj.transform.position.x))
            {
                obj.transform.position = new Vector3(-1 * obj.transform.position.x, obj.transform.position.y, 0);
            }
        }
    }
}
