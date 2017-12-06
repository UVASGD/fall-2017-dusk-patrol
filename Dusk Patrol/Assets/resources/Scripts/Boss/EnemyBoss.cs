using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : EnemyMovement
{

	public float targetY;

	public AudioPlayer player;

	public BossBar bossbar;


	bool retreating;

	void Start() {
		retreating = false;
	}

    // Update is called once per frame
    void Update()
    {
		if (retreating) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -1) * speed * Time.deltaTime * TimeManager.timeFactor * 2;
			return;
		}
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

	public void retreat() {
		retreating = true;
	}

}
