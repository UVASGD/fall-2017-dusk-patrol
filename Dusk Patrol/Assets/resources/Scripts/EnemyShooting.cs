using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject enemyBullet;

    private float maxCoolDown = 0.3f;
    private float currCoolDown = 0f;

    void Update()
    {
        float random = Random.Range(0f, 100f);
        if (random < 30f)
        {
            Shoot(enemyBullet);
        }
    }

    void Shoot(GameObject bullet)
    {
        if (currCoolDown > maxCoolDown)
        {
            Instantiate(enemyBullet, transform.position - 2f * Vector3.up, Quaternion.identity);
            currCoolDown = 0f;
        }
        currCoolDown += Time.deltaTime;
    }
}
