using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : EnemyShooting
{
    void Awake()
    {
        health = gameObject.transform.parent.GetComponent<HealthScript>();

        shootTimes = new float[10];
        for (int i = 0; i < shootTimes.Length; i++)
        {
            shootTimes[i] = Random.Range(100f, 500f) / 100f;
        }
    }

    void Update()
    {
        if (!health.isDead)
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
    }

    void ShootBullet(GameObject bullet)
    {
        Instantiate(enemyBullet, transform.position - Vector3.up * 0.5f, Quaternion.identity);
    }
}
