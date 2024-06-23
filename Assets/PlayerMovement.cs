using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public GameObject interactable;
    private Vector2 moveDirection;
    [SerializeField]private Material skin;
    [SerializeField] private float Gravmag;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    //for physics calculations
    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed * Time.deltaTime, moveDirection.y * moveSpeed * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D interactable) {

        // TODO: Decouple this interaction and put in interactable script.
        interactable.GetComponent<Rigidbody2D>().gravityScale = Gravmag * Time.deltaTime;
    } 
}





