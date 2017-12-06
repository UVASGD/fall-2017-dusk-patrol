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
    private float leftAngle = 20f;
    private float rightAngle = 160f;
    private float targetAngle;
    private float angleDiff;
    private float coolDownDir = 1; // 1 for coolDown right to left, -1 for coolDown left to right
    private bool setDir = false;

    private Transform laserCannon;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        light = transform.parent.GetComponent<Light>();

        angleDiff = rightAngle - leftAngle;
        targetAngle = leftAngle;

        laserCannon = transform.parent;

        laserCannon.rotation = Quaternion.Euler(0, 0, rightAngle);
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
                if(coolDownDir == 1) //fire left to right
                    laserCannon.rotation = Quaternion.Euler(0, 0, leftAngle + (timer / maxTime) * angleDiff);
                else //fire right to left
                    laserCannon.rotation = Quaternion.Euler(0, 0, rightAngle - (timer / maxTime) * angleDiff);
                light.intensity = (maxTime - timer) / maxTime;
            }
        }
        if (isCoolDown)
        {
            if (timer >= coolDownTime)
            {
                timer = 0;
                isCoolDown = false;
                isCharging = true;
                setDir = false;
            }
            else
            {
                if (coolDownDir == 1)
                    laserCannon.rotation = Quaternion.Euler(0, 0, rightAngle - (timer / maxTime) * angleDiff);
                else
                    laserCannon.rotation = Quaternion.Euler(0, 0, leftAngle + (timer / maxTime) * angleDiff);
                if (!setDir && (laserCannon.rotation.eulerAngles.z >= 89f && laserCannon.rotation.eulerAngles.z <= 91f))
                {
                    if (Random.Range(0.0f, 1.0f) > 0.5f)
                    {
                        coolDownDir = 1;
                    }
                    else
                        coolDownDir = -1;
                    setDir = true;
                }
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
    }

    void StopLaser()
    {
        collider.enabled = false;
        sprite.enabled = false;
        isFiring = false;
    }
}
