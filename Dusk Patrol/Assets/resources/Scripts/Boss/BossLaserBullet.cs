using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossLaserBullet : MonoBehaviour
{
    public int level;

    private Rigidbody2D rigidBody;
    private Collider2D collider;
    private SpriteRenderer sprite;
    private Light light;
    private float timer = 0f;
    private float fireTime;
    private float coolDownTime;
    private float chargeTime;
    private float damage;
    private bool isFiring = false;
    private bool isCoolDown = true;
    private bool isCharging = false;
    private float leftAngle = 20f;
    private float rightAngle = 160f;
    private float targetAngle;
    private float angleDiff;
    private float coolDownDir = 1; // 1 for coolDown right to left, -1 for coolDown left to right
    private bool setDir = false;
    private GameObject player;

    private Transform laserCannon;

	private bool freakout;
	private float freakAmount;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        light = transform.parent.GetComponent<Light>();
        player = GameObject.Find("Player");

        angleDiff = rightAngle - leftAngle;
        targetAngle = leftAngle;

        laserCannon = transform.parent;

        laserCannon.rotation = Quaternion.Euler(0, 0, rightAngle);

        if (level == 1)
        {
            fireTime = 3f;
            coolDownTime = 5f;
            chargeTime = 2f;
            damage = 20f;
        }
        if (level == 2)
        {
            fireTime = 2;
            coolDownTime = 3f;
            chargeTime = 1f;
            damage = 40f;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime * TimeManager.timeFactor;

		if (freakout) {
			freakAmount += Time.deltaTime * TimeManager.timeFactor;
			light.intensity = freakAmount;
			if (freakAmount > 1) {
				light.range = light.range + Time.deltaTime * TimeManager.timeFactor;
			}
			if (freakAmount > 3) {
				SceneManager.LoadScene ("END");
			}
			return;
		}

		Vector3 viewPos = Camera.main.WorldToViewportPoint(gameObject.transform.position);
		if (viewPos.y < 0 || viewPos.y > 1) {
			return;
		}

        if (isFiring)
        {
            if (timer >= fireTime)
            {
                StopLaser();
                isCoolDown = true;
                timer = 0;
            }
            else
            {
                if(coolDownDir == 1) //fire left to right
                    laserCannon.rotation = Quaternion.Euler(0, 0, leftAngle + (timer / fireTime) * angleDiff);
                else //fire right to left
                    laserCannon.rotation = Quaternion.Euler(0, 0, rightAngle - (timer / fireTime) * angleDiff);
                light.intensity = (fireTime - timer) / fireTime;
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
                    laserCannon.rotation = Quaternion.Euler(0, 0, rightAngle - (timer / coolDownTime) * angleDiff);
                else
                    laserCannon.rotation = Quaternion.Euler(0, 0, leftAngle + (timer / coolDownTime) * angleDiff);
                if (!setDir && (laserCannon.rotation.eulerAngles.z >= 89f && laserCannon.rotation.eulerAngles.z <= 91f))
                {
                    if (GetDirection())
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

    bool GetDirection()
    {
        if (level == 1)
        {
            return Random.Range(0.0f, 1.0f) > 0.5f;
        }
        else //level == 2
        {
            if (Random.Range(0.0f, 1.0f) > 0.7f) //move toward player
            {
                if (player.transform.position.x < 0) //if player on left side
                    return true;
                else
                    return false;
            }
            else
            {
                if (player.transform.position.x < 0) //if player on left side
                    return false;
                else
                    return true;
            }
        }
    }

	public void freakTheFuckOut() {
		if (!freakout) {
			freakout = true;
			freakAmount = 0;
		}
	}
}
