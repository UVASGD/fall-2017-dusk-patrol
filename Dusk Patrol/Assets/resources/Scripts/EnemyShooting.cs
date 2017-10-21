using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject enemyBullet;

    private HealthScript health;
    private float maxCoolDown = 0.3f;
    private float currCoolDown = 0f;
    private float[] shootTimes;

    private float timer = 0f;
    private int shootTimesIndex = 0;

    void Awake()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(gameObject.transform.position);
        if (viewPos.x > 1 || viewPos.x<0)
            return;
        if (viewPos.y > 1|| viewPos.y<0)
            return;


        float random = Random.Range(0f, 100f);
        if (random < 30f)
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
            Debug.Log("Not Dead");
            if (TimeManager.timeFactor > 0)
            {
                timer += Time.deltaTime * TimeManager.timeFactor;
                if (timer >= shootTimes[shootTimesIndex])
                {
                    Shoot(enemyBullet);
                    shootTimesIndex++;
                    if (shootTimesIndex <= shootTimes.Length)
                        shootTimesIndex = 0;
                    timer = 0;
                }
            }
            else if (TimeManager.timeFactor <= 0)
            {
                timer -= Time.deltaTime * TimeManager.timeFactor;
                if (timer < 0f)
                {
                    if(shootTimesIndex > 0)
                        shootTimesIndex--;
                    timer = shootTimes[shootTimesIndex];
                }
            }
        }
    }

    void Shoot(GameObject bullet)
    {
        Instantiate(enemyBullet, transform.position - Vector3.up, Quaternion.identity);
    }
}
