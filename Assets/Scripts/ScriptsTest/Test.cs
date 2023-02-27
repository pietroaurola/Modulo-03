using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test: MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Rigidbody rb;
    [SerializeField] LayerMask groundMask;


    bool isGrounded = false;

    //public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float xMove = Input.GetAxisRaw("Vertical");  //GetAxis no mezze misure, GetAxisRaw aggiunge mezze misure da tool, altrimenti regolazione a mano da Unity/Edit/Project Secting/Input Manager
        float zMove = Input.GetAxisRaw("Horizontal");


        //costruisco il vettore di movimwento
        Vector3 playerMovement = (Vector3.left * xMove + Vector3.forward * zMove).normalized * speed /** Time.deltaTime */;

        //applico la mia velocità al vettore di movimento
        playerMovement.y = rb.velocity.y;


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerMovement.y += Mathf.Sqrt(jumpForce * -2f * (-9.81f));
        }

        //applico il vettore di movimento al rigidbody
        rb.velocity = playerMovement;


        //Debug.DrawRay(transform.position, -transform.up * 5, Color.cyan);

        //RaycastHit;
        if (Physics.Raycast(transform.position, -transform.forward, 5, groundMask))
        {
            Debug.Log("Colpito");
        }
    }

    private void OnCollisionEnter(Collision other) // quando collide
    {
        //Debug.Log(collision.transform.name);

        if (other.transform.name == "Cube")
        {
            DestroyObject(other.gameObject);
        }

        if (other.transform.CompareTag("Ground")) //se collide con tag Ground è true riprendendo la funzione (Input.GetButtonDown("Jump") && isGrounded) sopra
        {
            isGrounded = true;
        }

    }

    private void OnTriggerExit(Collider other) //se non collide con tag Ground è false riprendendo la funzione (Input.GetButtonDown("Jump") && isGrounded) sopra
    {
        if (other.transform.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    //private void OnCollisionExit(Collision collision) quando non tocca
    //private void OnCollisionStay(Collision collision) mentre rimane
    //private void OnTriggerEnter(Collider other) quando è trigger 



}