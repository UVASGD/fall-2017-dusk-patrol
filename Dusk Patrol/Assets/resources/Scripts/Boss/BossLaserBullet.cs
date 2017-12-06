using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaserBullet : MonoBehaviour
{
    public float damage;
    public float speed;
    public float maxTime;
    public float coolDownTime;
    public float chargeTime;

    private Rigidbody2D rigidBody;
    private Collider2D collider;
    private SpriteRenderer sprite;
    private Light light;
    private float timer = 0f;
    private bool isFiring = false;
    private bool isCoolDown = true;
    private bool isCharging = false;
    private float baseAngle = 20f;
    private float maxAngle = 160f;
    private float angleDiff;

    private Transform laserCannon;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        light = transform.parent.GetComponent<Light>();

        angleDiff = maxAngle - baseAngle;

        laserCannon = transform.parent;

        laserCannon.rotation = Quaternion.Euler(0, 0, maxAngle);
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime * TimeManager.timeFactor;
        if (isFiring)
        {
            if (timer >= maxTime)
            {
                StopLaser();
                isCoolDown = true;
                timer = 0;
            }
            else
            {
                laserCannon.rotation = Quaternion.Euler(0, 0, baseAngle + (timer / maxTime) * angleDiff);
                light.intensity = (maxTime - timer) / maxTime;
            }
        }
        if (isCoolDown)
        {
            if (timer >= coolDownTime)
            {
                timer = 0;
                ChargeLaser();
                isCoolDown = false;
                isCharging = true;
            }
            else
            {
                laserCannon.rotation = Quaternion.Euler(0, 0, maxAngle - (timer / coolDownTime) * angleDiff);
            }
        }
        if (isCharging)
        {
            if (timer >= chargeTime)
            {
                timer = 0;
                ShootLaser();
                isCoolDown = false;
                isCharging = false;
            }
            else
            {
                //sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, timer / chargeTime);
                light.intensity = timer / chargeTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (TimeManager.timeFactor > 0 && col.gameObject.GetComponent<HealthScript>())
        {
            if (col.tag.Equals("Player"))
            {
                col.gameObject.GetComponent<HealthScript>().TakeDamage(damage);
            }
        }
    }

    void ShootLaser()
    {
        collider.enabled = true;
        sprite.enabled = true;
        isFiring = true;
        laserCannon.rotation = Quaternion.Euler(0, 0, baseAngle);
    }

    void StopLaser()
    {
        collider.enabled = false;
        sprite.enabled = false;
        isFiring = false;
    }

    void ChargeLaser()
    {
        //sprite.enabled = true;
    }
}
