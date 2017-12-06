using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaserBullet : MonoBehaviour {

    public float damage;
    public float speed;
    private Rigidbody2D rigidBody;
    private Collider2D collider;
    private SpriteRenderer sprite;
    private float timer = 0f;
    private float maxTime = 7f;
    private bool isFiring = false;
    private float baseAngle = 20f;
    private float maxAngle = 160f;
    private float angleDiff;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();

        angleDiff = maxAngle - baseAngle;
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime * TimeManager.timeFactor;
        if (timer >= maxTime)
        {
            StopLaser();
            timer = 0;
        }
        if (isFiring)
        {
            transform.rotation = Quaternion.Euler(0, 0, baseAngle + (timer/maxTime) * angleDiff);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (TimeManager.timeFactor > 0 && col.gameObject.GetComponent<HealthScript>())
        {
            if (col.tag.Equals("Player"))
            {
                col.gameObject.GetComponent<HealthScript>().TakeDamage(damage);
                Debug.Log(col.name + "Damage");
            }
        }
    }

    public void ShootLaser()
    {
        collider.enabled = true;
        sprite.enabled = true;
        transform.rotation = Quaternion.Euler(0, 0, 40f);
        isFiring = true;
    }

    public void StopLaser()
    {
        collider.enabled = false;
        sprite.enabled = false;
        isFiring = false;
    }
}
