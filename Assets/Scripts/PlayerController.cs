using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool grounded;
    [SerializeField] Rigidbody rb;

    [Header("Movement Settings")]
    [SerializeField] float speed = 7f;

    [Header("Jump Settings")]
    [SerializeField] float jumpHeight = 10; //altezza che si raggiunge con il salto
    [SerializeField] int maxJumpCount = 2; //numero di salti a disposizione
    [SerializeField] int jumpsRemaining = 0;

    public Vector2 turn;
    public float sensitivity = 0.5f;

  
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Vertical");
        float zMove = Input.GetAxisRaw("Horizontal");

        //costruisco il vettore di movimwento
        Vector3 playerMovement = (Vector3.forward * xMove + Vector3.left * zMove).normalized * speed;

        //applico la mia velocità al vettore di movimento
        playerMovement.y = rb.velocity.y;

        //applico il vettore di movimento al rigidbody
        rb.velocity = playerMovement;


        //quando uso il comando Space e ho un numero di salti a disposizione maggiore di 0: creo una forza dal basso verso l'alto sul player con il limite del jumpHeight
        if ((Input.GetKeyDown(KeyCode.Space)) && (jumpsRemaining > 0))
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            jumpsRemaining -= 1; //sottraggo un salto dall'elenco
        }

        //rotazione camera con mouse
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
            jumpsRemaining = maxJumpCount;
        }
    }

    public void OnCollisionnExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}
