using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    [Header("Life")]
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

    void Die() //alla morte distruggo l'oggetto e avvio la scena menu vittoria
    {
        Cursor.lockState = CursorLockMode.Confined;

        Destroy(gameObject);

        m.YouWin();

    }
}
