using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDaughter : MonoBehaviour
{
    [Header("target da seguire")]
    public Transform target;
    
    [Header("Daughter Settings")]
    public float Speed;
    float CalcoloDistanza;
    public float distance;
    public float AreaDiAllerta;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        CalcoloDistanza = Vector3.Distance(transform.position, target.position); //calcolo distanza

        if (CalcoloDistanza < distance * AreaDiAllerta) //quando la distanza del player è inferiore della distanza di allerta l'enemy si gira verso il player
        {
            transform.LookAt(target);
        }

        if (CalcoloDistanza < distance) //quando la distanza del player è inferiore della distanza l'enemy si muove verso il player
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target.position, Speed * Time.fixedDeltaTime);
            rb.MovePosition(pos);
        }
    }
}
