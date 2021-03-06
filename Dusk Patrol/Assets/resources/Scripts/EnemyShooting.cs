﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject enemyBullet;

    protected HealthScript health;
    protected float maxCoolDown = 0.3f;
    protected float currCoolDown = 0f;
    protected float[] shootTimes;

    protected float timer = 0f;
    protected int shootTimesIndex = 0;

    protected void Awake()
    {
        /*Vector3 viewPos = Camera.main.WorldToViewportPoint(gameObject.transform.position);
        if (viewPos.x > 1 || viewPos.x<0)
            return;
        if (viewPos.y > 1|| viewPos.y<0)
            return;*/

        health = GetComponent<HealthScript>();

        shootTimes = new float[10];
        for (int i = 0; i < shootTimes.Length; i++)
        {
            shootTimes[i] = Random.Range(30f, 100f) / 100f;
        }
    }

    void Update()
    {
        if(!health.isDead)
        {
            if (TimeManager.timeFactor > 0)
            {
				Vector3 viewPos = Camera.main.WorldToViewportPoint(gameObject.transform.position);
				if (viewPos.y >= 0 && viewPos.y <= 1) {
					timer += Time.deltaTime * TimeManager.timeFactor;
					if (timer >= shootTimes [shootTimesIndex]) {
						Shoot (enemyBullet);
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
					if (viewPos.y >= 0 && viewPos.y <= 1) {
					timer -= Time.deltaTime * TimeManager.timeFactor;
					if (timer < 0f) {
						if (shootTimesIndex > 0)
							shootTimesIndex--;
						timer = shootTimes [shootTimesIndex];
					}
				}
            }
        }
    }

    void Shoot(GameObject bullet)
    {
        Instantiate(enemyBullet, transform.position - Vector3.up, Quaternion.identity);
    }
}
