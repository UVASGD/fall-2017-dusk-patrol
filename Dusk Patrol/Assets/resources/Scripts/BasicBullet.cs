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
            Debug.Log("Respawn Bullet");
        }
        if(!isDespawn)
            MoveBullet();
        else
            if (timer - despawnedTime >= TimeManager.timeLimit)
                Destroy(gameObject);
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
        GetComponent<SpriteRenderer>().enabled = false;
    }

    void OnBecameInvisible()
    {
        Debug.Log("Move Out of Screen");
        isDespawn = true;
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
