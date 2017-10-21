using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject enemyBullet;

    private float coolDownTimer = 0;
    private float[] shootTimes;
    private int shootTimesIndex = 0;

    void Awake()
    {
        //set random times greater than 0.3 seconds
        shootTimes = new float[20];
        for (int i = 0; i < shootTimes.Length; i++)
        {
            shootTimes[i] = Random.Range(30f, 100f)/100;
        }
    }

    void Update()
    {
        //if moving back in time, don't shoot
        if (TimeManager.timeFactor > 0f)
        {
            coolDownTimer += Time.deltaTime;
            if (coolDownTimer > shootTimes[shootTimesIndex])
            {
                Shoot(enemyBullet);
                shootTimesIndex++;
                if (shootTimesIndex >= shootTimes.Length)
                    shootTimesIndex = 0;
                coolDownTimer = 0;
            }
        }
        else if(TimeManager.timeFactor < 0f)
        {
            coolDownTimer -= Time.deltaTime;
            if (coolDownTimer < 0f && shootTimesIndex > 0)
            {
                shootTimesIndex--;
                coolDownTimer = shootTimes[shootTimesIndex];
            }
        }
    }

    void Shoot(GameObject bullet)
    {
        Instantiate(enemyBullet, transform.position - 2f * Vector3.up, Quaternion.identity);
    }
}
