using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpiral : EnemyMovement
{
    public float size;
    public override Vector2 getMovement(float t)
    {
        float x = speed*(size *Mathf.Sin(t));

        float y = (-speed * Mathf.Sin(t + (size - 1) * Mathf.PI / (size * 2)) - 120);

        return new Vector2(x, y);
    }


}

