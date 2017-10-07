using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float maxHealth;
    private float currHealth;

    void Awake()
    {
        currHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currHealth -= damage;
        if (currHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
