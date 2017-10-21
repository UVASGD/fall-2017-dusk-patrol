using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalLogEnemy : EnemyMovement {

	public float direction;

	public override Vector2 getMovement(float t) {
		float x = direction * Mathf.Exp(t) / (100*t);
		float y = -1;
		return new Vector2 (x, y);
	}
}
