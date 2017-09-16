using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    public float damage;
    private float speed = 2;
    private Rigidbody2D rigidBody;

	void Awake ()
    {
        rigidBody = GetComponent<Rigidbody2D>();	
	}
	
	void Update ()
    {
        MoveBullet();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
    }

    void MoveBullet()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
    }
}
