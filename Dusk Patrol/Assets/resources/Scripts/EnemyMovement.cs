﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed;
	public  float colDamage;
    private Rigidbody2D myRigidBody;
    private Vector2 movement;
    private float t;

	public TimeManager tm;

    // Use this for initialization
    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        movement = new Vector2(0, 0);
        t = 0;
    }

	private void Start() {
		if (tm == null) {
			tm = FindObjectOfType<TimeManager> ();
		}
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<HealthScript>().TakeDamage(colDamage);
        this.GetComponent<HealthScript>().TakeDamage(colDamage);
    }

    // Update is called once per frame
    void Update () {
		t += Time.deltaTime * tm.timeFactor;
        movement = this.getMovement(t);
		myRigidBody.velocity = movement * speed * Time.deltaTime * tm.timeFactor;
     }

    public virtual Vector2 getMovement(float t)
    {
        float x = t;
        float y = Mathf.Log(t) + 4;
        // float y = -Mathf.Log(t) + 4;
        // x = [0, 2(Pi)]
        // float z = ?;
        // float c = some constant;
        // float y = z*c(Mathf.cos(c*t);
        return new Vector2(x, y);
    }
}
