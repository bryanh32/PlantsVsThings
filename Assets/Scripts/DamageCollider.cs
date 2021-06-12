using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<Attacker>())
        {
            FindObjectOfType<HeartDisplay>().TakeHealthDamage(collision.GetComponent<Attacker>().GetHealthDamage());
            Destroy(collision.gameObject);
        }
    }
}
