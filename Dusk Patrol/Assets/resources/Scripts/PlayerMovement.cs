using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject bullet;

    private Rigidbody2D rigidBody;
    private Vector2 leftGun;
    private Vector2 rightGun;
    private float speed = 7f;
    private float maxCoolDown = 0.2f; // 1/5th of a second
    private float currCoolDown = 0f;
    private float horizScale = 1.1f; //scale used to get the location of the guns
    private float vertScale = 1.5f; //scale used to set how far in front of the plane to make the bullets

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        SetGunLocations();
    }
	
	void Update ()
    {
        if (TimeManager.timeFactor > 0)
        {
            MovePlayer();
            Shoot(bullet);
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
        }

        SetGunLocations();
    }

    void MovePlayer()
    {
        float translationX = Input.GetAxis("Horizontal");
        float translationY = Input.GetAxis("Vertical");

        rigidBody.velocity = new Vector2(translationX, translationY) * speed;
        CameraScript.WrapAround(gameObject);
    }

    void Shoot(GameObject bullet)
    {
        if (currCoolDown > maxCoolDown)
        {
            if (Input.GetButton("Fire1"))
            {
                GameObject bullet1 = Instantiate(bullet, leftGun, transform.rotation);
                GameObject bullet2 = Instantiate(bullet, rightGun, transform.rotation);

                bullet1.GetComponent<BasicBullet>().setAsPlayerBullet();
                bullet2.GetComponent<BasicBullet>().setAsPlayerBullet();
            }
            currCoolDown = 0f;
        }
        currCoolDown += Time.deltaTime;
    }

    void SetGunLocations()
    {
        leftGun = transform.position + horizScale * Vector3.left + vertScale * Vector3.up;
        rightGun = transform.position - horizScale * Vector3.left + vertScale * Vector3.up;
    }
}
