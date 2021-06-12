using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float rotation = 0.5f;
    [SerializeField] float damage = 100;


    public void Update()
    {
        Vector3 translation = new Vector3(speed * Time.deltaTime, 0, rotation * Time.deltaTime);
        transform.Translate(translation);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Attacker attacker = other.GetComponent<Attacker>();
        Health health = attacker.GetComponent<Health>();
        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
        if (!attacker)
        {
            return;
        }
    }

}
