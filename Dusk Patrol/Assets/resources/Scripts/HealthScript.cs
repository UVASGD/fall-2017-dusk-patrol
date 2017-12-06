using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public float maxHealth;
    public bool isDead = false;
	public bool isPlayer;

	public AudioClip enemydeath;

    protected float currHealth;
    protected float timer = 0;
    protected float timeDead = 0f;
    protected Stack<HealthTime> healthStack;

    protected void Awake()
    {
        healthStack = new Stack<HealthTime>();
        currHealth = maxHealth;
    }

    void Update()
    {
        timer += Time.deltaTime * TimeManager.timeFactor;

        if (healthStack.Count != 0 && timer <= healthStack.Peek().getTime())
        {
            HealthTime ht = healthStack.Pop();
            currHealth = ht.getHealth();
        }

        if (timer <= timeDead)
        {
            isDead = false;
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
			if (isPlayer) {
				GetComponent<PlayerMovement> ().enabled = true;
			} else {
				GetComponent<EnemyMovement> ().enabled = true;
			}
            timeDead = 0f;
        }
    }

    public void TakeDamage(float damage)
    {
		healthStack.Push(new HealthTime(currHealth, timer));
        currHealth -= damage; 

        if (currHealth <= 0)
        {
			if (isPlayer) {
				SceneManager.LoadScene (3);
			}
            isDead = true;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
			if (isPlayer) {
				//GetComponent<PlayerMovement> ().enabled = false;
			} else {
				//GetComponent<EnemyMovement> ().enabled = false;
				AudioSource.PlayClipAtPoint (enemydeath, gameObject.transform.position, OptionScript.loadSettings ().SFX);
			}
            timeDead = timer;
        }
    }

	public float getHealth(){
		return currHealth;
	}
}

public class HealthTime
{
    private float health;
    private float time;

    public HealthTime(float h, float t)
    {
        health = h;
        time = t;
    }

    public float getHealth()
    {
        return health;
    }

    public float getTime()
    {
        return time;
    }
}
