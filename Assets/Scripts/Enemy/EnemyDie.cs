using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    public float health = 50f;
    MenuController m;

    private void Start()
    {
        m = FindObjectOfType<MenuController>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Cursor.lockState = CursorLockMode.Confined;

        Destroy(gameObject);

        m.YouWin();

    }
}
