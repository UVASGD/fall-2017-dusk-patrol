using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : EnemyMovement
{

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime * TimeManager.timeFactor;
        movement = this.getMovement(t).normalized;
        myRigidBody.velocity = movement * speed * Time.deltaTime * TimeManager.timeFactor;

        CameraScript.WrapAround(gameObject);
    }

    public virtual Vector2 getMovement(float t)
    {
        return new Vector2(0, 0);
    }

}
