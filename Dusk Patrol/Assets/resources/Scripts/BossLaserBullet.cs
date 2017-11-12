using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaserBullet : MonoBehaviour {

    public float damage;
    public float speed;
    private Rigidbody2D rigidBody;
    private float isEnemyBullet = -1; //default as enemy bullet
    private float timer = 0f;
    private float despawnedTime = 0f;
    private bool isDespawn = false;
    private bool respawned = false;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime * TimeManager.timeFactor;
        if (timer <= 0f)
            Destroy(gameObject);

        if (timer <= despawnedTime)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
            isDespawn = false;
        }

        //if (!isDespawn)
        //    MoveBullet();

        if ((timer - despawnedTime) >= .01f)
        {
            Destroy(gameObject);
        }

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if ((viewPos.y > 1 || viewPos.y < 0) && TimeManager.timeFactor > 0 && !isDespawn)
        {
            isDespawn = true;
            despawnedTime = timer;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (TimeManager.timeFactor > 0 && col.gameObject.GetComponent<HealthScript>())
        {
            if (isEnemyBullet == -1 && col.tag.Equals("Player") || isEnemyBullet == 1 && col.tag.Equals("Enemy"))
            {
                col.gameObject.GetComponent<HealthScript>().TakeDamage(damage);
                despawnedTime = timer;
                isDespawn = true;
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Collider2D>().enabled = false;
                Debug.Log(col.name + "Damage");
            }
        }
    }

    void MoveBullet()
    {
        rigidBody.velocity = isEnemyBullet * speed * GetMovement(timer) * Time.deltaTime * TimeManager.timeFactor;
    }

    Vector2 GetMovement(float t)
    {
        return new Vector2(0, 2);
    }
}
