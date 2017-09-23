using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject bullet;

    private Vector2 leftGun;
    private Vector2 rightGun;
    private float speed = 7f;
    private float maxCoolDown = 0.2f; // 1/5th of a second
    private float currCoolDown = 0f;

    void Awake()
    {
        SetGunLocations();
    }
	
	void Update ()
    {
        MovePlayer();
        Shoot(bullet);

        SetGunLocations();
    }

    void MovePlayer()
    {
        float translationX = Input.GetAxis("Horizontal");
        float translationY = Input.GetAxis("Vertical");

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(translationX, translationY) * speed;
    }

    void Shoot(GameObject bullet)
    {
        if (currCoolDown > maxCoolDown)
        {
            if (Input.GetButton("Jump"))
            {
                Instantiate(bullet, leftGun, transform.rotation);
                Instantiate(bullet, rightGun, transform.rotation);
            }
            currCoolDown = 0f;
        }
        currCoolDown += Time.deltaTime;
    }

    void SetGunLocations()
    {
        leftGun = transform.position + 1.1f * Vector3.left + 1.5f * Vector3.up;
        rightGun = transform.position - 1.1f * Vector3.left + 1.5f * Vector3.up;
    }
}
