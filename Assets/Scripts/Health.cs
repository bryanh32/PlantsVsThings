using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float startingHealth = 100f;
    [SerializeField] GameObject deathEffect;

    public void DealDamage(float damage)
    {
        startingHealth -= damage;

        if (startingHealth <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathEffect)
        {
            return;
        }
        Vector2 deathOffset = new Vector2(transform.position.x + GetComponent<BoxCollider2D>().offset.x, transform.position.y + GetComponent<BoxCollider2D>().offset.y);
        GameObject vfx = Instantiate(deathEffect, deathOffset, transform.rotation);
        Destroy(vfx, 1f);
    }
}
