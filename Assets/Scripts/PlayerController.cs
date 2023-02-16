using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Rigidbody rb;
    [SerializeField] LayerMask groundMask;


    bool isGrounded = false;

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
            playerMovement.y += Mathf.Sqrt(jumpForce * -2f * (-9.81f));
        }

        //applico il vettore di movimento al rigidbody
        rb.velocity = playerMovement;

    }

    private void OnCollisionEnter(Collision other) // quando collide
    {
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

    
}
