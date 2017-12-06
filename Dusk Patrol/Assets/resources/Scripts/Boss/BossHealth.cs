using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : HealthScript
{
    private SpriteRenderer cannon, rightGun, leftGun;

    protected void Awake()
    {
        base.Awake();
        cannon = gameObject.transform.Find("boss cannon").GetComponent<SpriteRenderer>();
        rightGun = gameObject.transform.Find("boss gun right").GetComponent<SpriteRenderer>();
        leftGun = gameObject.transform.Find("boss gun left").GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        healthStack.Push(new HealthTime(currHealth, timer));
        currHealth -= damage;

        if (currHealth <= 0)
        {
            isDead = true;
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(enemydeath, gameObject.transform.position, OptionScript.loadSettings().SFX);
            timeDead = timer;
        }
    }
}
