using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMother : MonoBehaviour
{
    [Header("Enemy Movement")]
    public float torque = 5f;
    public float thrust = 80f;
    private Rigidbody rb;
    public Transform center;

    [Header("Daughter spawn")]
    public GameObject EnemyToSpawn;

    public float spawnTime = 2f;
    float spawnTimer;

    public float spawnRange = 10f;
    public Vector3 minPosition;
    public Vector3 maxPosition;

    public GameObject Home;

    [Header("Life")]
    public float health = 0f;

    private MenuController m;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        m = FindObjectOfType<MenuController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(center);

        Vector3 targetLocation = center.position - transform.position;
        float distance = targetLocation.magnitude;
        rb.AddRelativeForce(Mathf.Clamp((distance - 10) / 50, 0f, 1f) * thrust * Vector3.forward); //serve per creare l'effetto elastico per il muovimento della madre


        spawnTimer += Time.deltaTime; //spawn daugheter
        if(spawnTimer >= spawnTime)
        {
            Vector3 randomPosition = new Vector3(Random.Range(minPosition.x, maxPosition.x), Random.Range(minPosition.y, maxPosition.y), Random.Range(minPosition.z, maxPosition.z));

            Instantiate(EnemyToSpawn, randomPosition, Quaternion.identity, Home.transform);

            spawnTimer = 0;
        }
    }
}
