using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] Rigidbody rb;
    [SerializeField] float moveSpeed;
    [SerializeField] Transform orientation;


    [Header("Pulse Settings")]
    [SerializeField] float pulse = 10;


    [Header("Mouse Settings")]
    [SerializeField] float sensitivity = 0.5f;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    public Vector3 turn;


    private MenuController m;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;

        m = FindObjectOfType<MenuController>();
    }


    private void FixedUpdate()
    {
        MovePlayer();

        MyInput();

        turn.y += Input.GetAxisRaw("Mouse Y") * sensitivity; //MI PERMETTE DI RUOTARE LA CAM SULL'ASSE Y
        turn.x += Input.GetAxisRaw("Mouse X") * sensitivity; //MI PERMETTE DI RUOTARE LA CAM SULL'ASSE X
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0); //MI PERMETTE DI CAMBIARE LA DIREZIONE DELLE FORZE QUANDO RUOTO ASSI
    }

    private void MovePlayer() //mi permette di applicare delle forze sui imput
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveSpeed * pulse * moveDirection.normalized, ForceMode.Force);
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal"); //mi crea il vettore horizontale
        verticalInput = Input.GetAxisRaw("Vertical"); //mi crea il vettore verticale

        if (Input.GetKey(KeyCode.E)) //con tasto E creo una forza che mi sposta verso l'alto
        {
            rb.AddForce(Vector3.up * pulse);
        }

        if (Input.GetKey(KeyCode.Q)) //con tasto Q creo una forza che mi sposta verso il basso
        {
            rb.AddForce(Vector3.down * pulse);
        }
    }

    private void OnTriggerEnter(Collider other) //quando il collider del player tocca un enemy mi carica la scena di gameover
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //SceneManager.LoadScene(2);
            m.GameOver();
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
