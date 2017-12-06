using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : EnemyMovement
{

	public float targetY;

	public AudioPlayer player;

	public BossBar bossbar;


	void Start() {

	}

    // Update is called once per frame
    void Update()
    {
		Vector3 viewPos = Camera.main.WorldToViewportPoint(gameObject.transform.position);
		if (viewPos.y >= 0 && viewPos.y <= 1) {
			player.goToBoss ();
			bossbar.turnOn();
		}
		if (gameObject.transform.position.y < targetY) {
			speed = 0;
		}
        t += Time.deltaTime * TimeManager.timeFactor;
        movement = this.getMovement(t).normalized;
		GetComponent<Rigidbody2D>().velocity = movement * speed * Time.deltaTime * TimeManager.timeFactor;
        CameraScript.WrapAround(gameObject);
    }

	public virtual Vector2 getMovement(float t)
    {
		return new Vector2 (0, 1);
    }

}
