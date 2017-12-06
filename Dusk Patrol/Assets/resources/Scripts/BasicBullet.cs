using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{

	public AudioClip clip;
    public float damage;
    public float speed;
    protected Rigidbody2D rigidBody;
    protected float isEnemyBullet = -1; //default as enemy bullet
    protected float timer = 0f;
    protected float despawnedTime = 0f;
    protected bool isDespawn = false;
    protected bool respawned = false;

	void Awake ()
    {
        rigidBody = GetComponent<Rigidbody2D>();	
	}
	
	void Update ()
    {
        timer += Time.deltaTime * TimeManager.timeFactor;
        if (timer <= 0f)
            Destroy(gameObject);

		if (timer <= despawnedTime && isDespawn)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
            isDespawn = false;
        }

		if (!isDespawn)
			MoveBullet ();
		else
			rigidBody.velocity = new Vector2 (0, 0);
		

        if ((timer - despawnedTime) >= TimeManager.timeLimit)
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

    public void setAsPlayerBullet()
    {
        isEnemyBullet = 1;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
		if (TimeManager.timeFactor > 0 && col.gameObject.GetComponent<HealthScript>())
        {
            if (isEnemyBullet == -1 && col.tag.Equals("Player") || isEnemyBullet == 1 && col.tag.Equals("Enemy"))
            {
                if (col.gameObject.GetComponent<BossHealth>())
                    col.gameObject.GetComponent<BossHealth>().TakeDamage(damage);
                else
                    col.gameObject.GetComponent<HealthScript>().TakeDamage(damage);
                despawnedTime = timer;
                isDespawn = true;
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Collider2D>().enabled = false;
                Debug.Log(col.name + "Damage");
				AudioSource.PlayClipAtPoint (clip, gameObject.transform.position, OptionScript.loadSettings ().SFX);
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
