using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStripes : EnemyMovement
{
    public float direction;

    public override Vector2 getMovement(float t)
    {
        float x = 1;
        float y = -0.5f;
        return new Vector2(x, y);
    }
}
