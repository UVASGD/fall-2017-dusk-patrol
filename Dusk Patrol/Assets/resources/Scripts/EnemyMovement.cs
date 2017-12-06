using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float speed;
	public  float colDamage;
    protected Rigidbody2D myRigidBody;
    protected Vector2 movement;
    protected float t;

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

    /*void OnTriggerEnter2D(Collider2D collision)
    {
		if (TimeManager.timeFactor > 0) {
			if (collision.gameObject.GetComponent<HealthScript> ())
				collision.gameObject.GetComponent<HealthScript> ().TakeDamage (colDamage);
			this.GetComponent<HealthScript> ().TakeDamage (colDamage);
		}
    }*/

    // Update is called once per frame
    void Update () {
		t += Time.deltaTime * TimeManager.timeFactor;
		movement = this.getMovement(t).normalized;
		myRigidBody.velocity = movement * speed * Time.deltaTime * TimeManager.timeFactor;

		CameraScript.WrapAround(gameObject);
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
