using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaserShooting : MonoBehaviour {

    public GameObject bossLaser;
    private HealthScript health;
    private float maxCoolDown = 1f;
    private float currCoolDown = 0f;
    private float[] shootTimes;

    private float timer = 0f;
    private int shootTimesIndex = 0;

    private void Awake()
    {
        health = GetComponent < HealthScript >();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!health.isDead)
        {
            if (TimeManager.timeFactor > 0)
            {
                Vector3 viewPos = Camera.main.WorldToViewportPoint(gameObject.transform.position);
                if (viewPos.y >= 0 && viewPos.y <= 1)
                {
                    timer += Time.deltaTime * TimeManager.timeFactor;
                    if (timer % 5f <=2)
                    {
                        Shoot(bossLaser);
                    
                    }
                    else
                    {
                        Despawn(bossLaser);
                    }
                }
            }
        }
    }
    void Shoot(GameObject bullet)
    {
        Vector3 shift = new Vector3(0, 0, 0);
        Instantiate(bossLaser, transform.position - Vector3.up - shift, Quaternion.Euler(0, 0, timer * 20f));
        //bullet.transform.eulerAngles = new Vector3(timer*2.0f, timer*2.0f, timer * 2.0f);
    }
    void Despawn(GameObject bullet)
    {
        Destroy(bullet);
    }
}
