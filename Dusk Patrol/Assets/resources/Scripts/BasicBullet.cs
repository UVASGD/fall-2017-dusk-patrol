using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    public float damage = 10;
    private float speed = 10;
    private Rigidbody2D rigidBody;
    private float isEnemyBullet = -1; //default as enemy bullet

	void Awake ()
    {
        rigidBody = GetComponent<Rigidbody2D>();	
	}
	
	void Update ()
    {
        MoveBullet();
    }

    public void setAsPlayerBullet()
    {
        isEnemyBullet = 1;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
        col.gameObject.GetComponent<HealthScript>().TakeDamage(damage);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void MoveBullet()
    {
        transform.position += isEnemyBullet * new Vector3(0, speed * Time.deltaTime, 0);
    }
}
