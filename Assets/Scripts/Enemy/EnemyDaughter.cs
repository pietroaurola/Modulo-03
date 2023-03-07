using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDaughter : MonoBehaviour
{
    public Transform target;
    public float Speed;
    float CalcoloDistanza;
    public float distance;
    public float AreaDiAllerta;

    void Update()
    {
        CalcoloDistanza = Vector3.Distance(transform.position, target.position);

        if(CalcoloDistanza < distance * AreaDiAllerta)
        {
            transform.LookAt(target);
        }

        if(CalcoloDistanza < distance)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * Speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy colpito");

        }
    }

}
