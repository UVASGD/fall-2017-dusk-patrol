using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : EnemyShooting
{
    public bool isBulletGun;

    private BossLaserBullet laser;

    private float laserCoolDown = 10f;

    void Awake()
    {
        base.Awake();
        health = gameObject.transform.parent.GetComponent<HealthScript>();
        if (!isBulletGun)
            laser = transform.Find("Laser").GetComponent<BossLaserBullet>();
    }

    void Update()
    {
        if (!health.isDead)
        {
            if (isBulletGun)
            {
                if (TimeManager.timeFactor > 0)
                {
                    Vector3 viewPos = Camera.main.WorldToViewportPoint(gameObject.transform.position);
                    if (viewPos.y >= 0 && viewPos.y <= 1)
                    {
                        timer += Time.deltaTime * TimeManager.timeFactor;
                        if (timer >= shootTimes[shootTimesIndex])
                        {
                            ShootBullet(enemyBullet);
                            shootTimesIndex++;
                            if (shootTimesIndex <= shootTimes.Length)
                                shootTimesIndex = 0;
                            timer = 0;
                        }
                    }
                }
                else if (TimeManager.timeFactor <= 0)
                {
                    Vector3 viewPos = Camera.main.WorldToViewportPoint(gameObject.transform.position);
                    if (viewPos.y >= 0 && viewPos.y <= 1)
                    {
                        timer -= Time.deltaTime * TimeManager.timeFactor;
                        if (timer < 0f)
                        {
                            if (shootTimesIndex > 0)
                                shootTimesIndex--;
                            timer = shootTimes[shootTimesIndex];
                        }
                    }
                }
            }
            else
            {
                if (TimeManager.timeFactor > 0)
                {
                    Vector3 viewPos = Camera.main.WorldToViewportPoint(gameObject.transform.position);
                    if (viewPos.y >= 0 && viewPos.y <= 1)
                    {
                        timer += Time.deltaTime * TimeManager.timeFactor;
                        if (timer >= laserCoolDown)
                        {
                            laser.ShootLaser();
                            timer = 0;
                        }
                    }
                }
            }
        }
    }

    void ShootBullet(GameObject bullet)
    {
        Instantiate(enemyBullet, transform.position - Vector3.up * 0.5f, Quaternion.identity);
    }
}
