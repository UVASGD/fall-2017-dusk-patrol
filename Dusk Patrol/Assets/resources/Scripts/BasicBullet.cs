using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    public float damage;
    public float speed;
    private Rigidbody2D rigidBody;
    private float isEnemyBullet = -1; //default as enemy bullet
    private float timer = 0f;
    private float despawnedTime = 0f;
    private bool isDespawn = false;

	void Awake ()
    {
        rigidBody = GetComponent<Rigidbody2D>();	
	}
	
	void Update ()
    {
        timer += Time.deltaTime * TimeManager.timeFactor;
        if (timer <= 0f)
            Destroy(gameObject);
        if (timer <= despawnedTime)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
            Debug.Log("Respawn Bullet");
        }

        if(!isDespawn)
            MoveBullet();

        if (timer - despawnedTime >= TimeManager.timeLimit)
            Destroy(gameObject);

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (Mathf.Abs(viewPos.y) > 1)
        {
            Debug.Log("Move Out of Screen");
            isDespawn = true;
            //GetComponent<SpriteRenderer>().enabled = false;
            //GetComponent<Collider2D>().enabled = false;
        }
    }

    public void setAsPlayerBullet()
    {
        isEnemyBullet = 1;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<HealthScript>())
        {
            if (isEnemyBullet == -1 && col.name.Equals("Player") || isEnemyBullet == 1 && col.name.Contains("Enemy"))
            {
                col.gameObject.GetComponent<HealthScript>().TakeDamage(damage);
                Debug.Log(col.name + "Damage");
            }
        }
        despawnedTime = timer;
        isDespawn = true;
        //GetComponent<SpriteRenderer>().enabled = false;
        //GetComponent<Collider2D>().enabled = false;
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
