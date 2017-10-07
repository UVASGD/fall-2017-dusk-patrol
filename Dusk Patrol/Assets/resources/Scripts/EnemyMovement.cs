using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private float speed = 10;
    private Rigidbody2D myRigidBody;
    private Vector2 movement;
    private float t;
    // Use this for initialization
    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        movement = new Vector2(0, 0);
        t = 0;
    }
    	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        movement = this.getMovement(t);
        gameObject.GetComponent<Rigidbody2D>().velocity = movement*speed*Time.deltaTime;
     }

    Vector2 getMovement(float t)
    {
        return new Vector2(1, -2 * t);
    }
}
