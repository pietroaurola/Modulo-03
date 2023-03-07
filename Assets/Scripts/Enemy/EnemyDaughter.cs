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

    
    public float BounceForce;

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

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.transform.tag == ("Enemy"))
    //    {
    //        Rigidbody otherRB = collision.rigidbody;
    //        otherRB.AddExplosionForce(BounceForce, collision.contacts[0].point, 5);
    //        Debug.Log("diooooooo");
    //    }
    //}

}
