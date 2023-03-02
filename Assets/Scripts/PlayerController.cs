using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool grounded;
    [SerializeField] Rigidbody rb;

    //[Header("Movement Settings")]
    //[SerializeField] float speed = 7;
    

    [Header("Pulse Settings")]
    //[SerializeField] float jump = 10;
    [SerializeField] float pulse = 10;//altezza che si raggiunge con il salto...ORA FORZA APPLICCATA
    //[SerializeField] int maxJumpCount = 2; //numero di salti a disposizione
    //[SerializeField] int jumpsRemaining = 0;
   
    public float moveSpeed;
    public Transform orientation;
    
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;

    [Header("Mouse Settings")]
    public Vector3 turn;
    public float sensitivity = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MyInput();

        turn.y += Input.GetAxisRaw("Mouse Y") * sensitivity; //MI PERMETTE DI RUOTARE LA CAM SULL'ASSE Y
        turn.x += Input.GetAxisRaw("Mouse X") * sensitivity; //MI PERMETTE DI RUOTARE LA CAM SULL'ASSE X
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0); //MI PERMETTE DI CAMBIARE LA DIREZIONE DELLE FORZE QUANDO RUOTO ASSI
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.E)) //&& (jumpsRemaining > 0))
        {
            rb.AddForce(Vector3.up * pulse);
            //jumpsRemaining -= 1; //sottraggo un salto dall'elenco
        }

        if (Input.GetKey(KeyCode.Q)) //&& (jumpsRemaining > 0))
        {
            rb.AddForce(Vector3.down * pulse);
            //jumpsRemaining -= 1; //sottraggo un salto dall'elenco
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * pulse, ForceMode.Force);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    //float xMove = Input.GetAxisRaw("Vertical");
    //    //float yMove = Input.GetAxisRaw("Horizontal");

    //    ////costruisco il vettore di movimwento
    //    //Vector3 playerMovement = (transform.forward * xMove + (-transform.right * yMove)).normalized * jump;

    //    ////applico la mia velocità al vettore di movimento
    //    //playerMovement.y = rb.velocity.y;


    //    ////applico il vettore di movimento al rigidbody
    //    //rb.velocity = playerMovement;


    //   //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      
    //    //wasd force easy
    //    rb.AddForce(Input.GetAxisRaw("Horizontal") * jump, 0, Input.GetAxisRaw("Vertical") * jump);

    //    //quando uso il comando Space e ho un numero di salti a disposizione maggiore di 0: creo una forza dal basso verso l'alto sul player con il limite del jumpHeight
    //    if (Input.GetKey(KeyCode.E)) //&& (jumpsRemaining > 0))
    //    {
    //        rb.AddForce(Vector3.up * jump);
    //        //jumpsRemaining -= 1; //sottraggo un salto dall'elenco
    //    }

    //    if (Input.GetKey(KeyCode.Q)) //&& (jumpsRemaining > 0))
    //    {
    //        rb.AddForce(Vector3.down * jump);
    //        //jumpsRemaining -= 1; //sottraggo un salto dall'elenco
    //    }

    //    //wasd
    //    //if (Input.GetKey(KeyCode.W)) //&& ()) //&& (jumpsRemaining > 0))
    //    //{
    //    //    rb.AddForce(Vector3.forward * jump);
    //    //    //jumpsRemaining -= 1; //sottraggo un salto dall'elenco
    //    //}

    //    //if (Input.GetKey(KeyCode.S)) //&& (jumpsRemaining > 0))
    //    //{
    //    //    rb.AddForce(Vector3.back * jump);
    //    //    //jumpsRemaining -= 1; //sottraggo un salto dall'elenco
    //    //}

    //    //if (Input.GetKey(KeyCode.D)) //&& (jumpsRemaining > 0))
    //    //{
    //    //    rb.AddForce(Vector3.right * jump);
    //    //    //jumpsRemaining -= 1; //sottraggo un salto dall'elenco
    //    //}

    //    //if (Input.GetKey(KeyCode.A)) //&& (jumpsRemaining > 0))
    //    //{
    //    //    rb.AddForce(Vector3.left * jump);
    //    //    //jumpsRemaining -= 1; //sottraggo un salto dall'elenco
    //    //}

        //rotazione camera con mouse
    //    turn.y += Input.GetAxisRaw("Mouse Y") * sensitivity; //MI PERMETTE DI RUOTARE LA CAM SULL'ASSE Y
    //    turn.x += Input.GetAxisRaw("Mouse X") * sensitivity; //MI PERMETTE DI RUOTARE LA CAM SULL'ASSE X
    //    transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0); //MI PERMETTE DI CAMBIARE LA DIREZIONE DELLE FORZE QUANDO RUOTO ASSI


    //}










    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
            //jumpsRemaining = maxJumpCount;
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
