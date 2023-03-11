using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDaughter : MonoBehaviour
{
    //per controllo distanza con il player
    public Transform target;
    public float Speed;
    float CalcoloDistanza;
    public float distance;
    public float AreaDiAllerta;

    Rigidbody rb;

    //per controllo distanza tra sorelle
    //public float nearDistance;
    //public float stoppingDistance;

    //public Transform Enemy;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    private void FixedUpdate()
    {
        CalcoloDistanza = Vector3.Distance(transform.position, target.position);

        if (CalcoloDistanza < distance * AreaDiAllerta)
        {
            transform.LookAt(target);
        }

        if (CalcoloDistanza < distance)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target.position, Speed * Time.fixedDeltaTime);
            rb.MovePosition(pos);
        }
    }

    void Update()
    {

        //CalcoloDistanza = Vector3.Distance(transform.position, target.position);

        //if(CalcoloDistanza < distance * AreaDiAllerta)
        //{
        //    transform.LookAt(target);
        //}

        //if(CalcoloDistanza < distance)
        //{
        //    transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * Speed);
        //}

        //calcolo distanza tra sorelle
        //if (Vector3.Distance(transform.position, Enemy.position) <= nearDistance)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, Enemy.position, -Speed * Time.deltaTime);
        //}
        //else if(Vector3.Distance(transform.position, Enemy.position) >stoppingDistance)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, Enemy.position, Speed * Time.deltaTime);
        //}
        //else if(Vector3.Distance(transform.position, Enemy.position) < stoppingDistance && Vector3.Distance(transform.position, Enemy.position) > nearDistance)
        //{
        //    transform.position = this.transform.position;
        //}


          
            //if(Vector3.Distance(transform.position, Enemy.position) < nearDistance)
            //{
            //    transform.position = Vector3.MoveTowards(transform.position, Enemy.position, -Speed * Time.deltaTime);
            //}
            //else if(Vector3.Distance(transform.position, Enemy.position) >stoppingDistance)
            //{
            //    transform.position = Vector3.MoveTowards(transform.position, Enemy.position, Speed * Time.deltaTime);
            //}
            //else if(Vector3.Distance(transform.position, Enemy.position) < stoppingDistance && Vector3
            //    .Distance(transform.position, Enemy.position) > nearDistance)
            //{
            //    transform.position = this.transform.position;
            //}
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
