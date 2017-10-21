using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZigZag : EnemyMovement {

    public float direction;

    public override Vector2 getMovement(float t)
    {
        float x = -1000*direction;
        float y=0;
        if (t<1)
        {
            y = 0;
        }
        else if(t>=1 && t<3){
            y = -1000;
        }
        else if(t>=3 && t<5){
            y = 1000;
        }
        else if(t>=5 && t<7)
        {
            y = -1000;
        }
        else if (t>=7)
        {
            y = 0;
        }

        //Debug.Log(" y " + y + " time " + t);
        return new Vector2(y, x);
    }
}
