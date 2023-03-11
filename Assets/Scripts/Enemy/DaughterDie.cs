using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaughterDie : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage(float amount)
    {
        Debug.Log("colpito");

        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
