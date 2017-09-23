using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKey("w"))
        //    gameObject.transform.position = gameObject.transform.position + (Vector3)new Vector2(0, 1);
        //if (Input.GetKey("a"))
        //    gameObject.transform.position = gameObject.transform.position + (Vector3)new Vector2(-1, 0);
        //if (Input.GetKey("s"))
        //    gameObject.transform.position = gameObject.transform.position + (Vector3)new Vector2(0, -1);
        //if (Input.GetKey("d"))
        //    gameObject.transform.position = gameObject.transform.position + (Vector3)new Vector2(1, 0);

        float translationX = Input.GetAxis("Horizontal");
        float translationY = Input.GetAxis("Vertical");

        float speed = 7f;

        //Vector2 move = new Vector2(translationX, translationY);
        //gameObject.transform.Translate((Vector3)move * Time.deltaTime * speed);

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(translationX, translationY) * speed;



    }
}
