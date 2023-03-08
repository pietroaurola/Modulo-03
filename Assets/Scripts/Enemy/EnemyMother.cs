using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMother : MonoBehaviour
{
    public float torque = 5f;
    public float thrust = 80f;
    private Rigidbody rb;
    public Transform center;

    //public GameObject EnemyMother;
    public GameObject EnemyToSpawn;
    public float spawnTime = 2f;
    public float spawnRange = 10f;
    public GameObject Home;

    float spawnTimer;
    public Vector3 minPosition;
    public Vector3 maxPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(center);

        Vector3 targetLocation = center.position - transform.position;
        float distance = targetLocation.magnitude;
        rb.AddRelativeForce(Vector3.forward * Mathf.Clamp((distance - 10) / 50, 0f, 1f) * thrust);

        spawnTimer += Time.deltaTime;

        if(spawnTimer >= spawnTime)
        {
            //Object.Instantiate(EnemyToSpawn, Random.insideUnitSphere * spawnRange, Quaternion.identity, Home.transform);
            //spawnTimer = 0;

            Vector3 randomPosition = new Vector3(Random.Range(minPosition.x, maxPosition.x), Random.Range(minPosition.y, maxPosition.y), Random.Range(minPosition.z, maxPosition.z));
            Instantiate(EnemyToSpawn, randomPosition, Quaternion.identity, Home.transform);

            spawnTimer = 0;
        }
    }
}
