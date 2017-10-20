using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed = 10;
	public  float colDamage = 10;
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
        gameObject.GetComponent<Rigidbody2D>().velocity = movement * speed * Time.deltaTime * tm.timeFactor;
        CameraScript.WrapAround(gameObject);
    }

    Vector2 getMovement(float t)
    {
        return new Vector2(1, -2 * t);
    }
}
