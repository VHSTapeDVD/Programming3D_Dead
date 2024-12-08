using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float Speed;

    public float Drag;
    public Transform orientation;

    [Header("Grounded check")]
    public float playerHeight;
    public LayerMask ThisisGrounded;
    bool isGrounded;


    float horizontalMovement;
    float verticalMovement;

    Vector3 moveDirection;

    Rigidbody rb;  

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        MovePlayer();
        SpeedLimit();
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 1f + 0.3f, ThisisGrounded);

        PlayerInput();
        
       if (isGrounded)
       {
        
           rb.drag = Drag;
       }
       else
       {
           rb.drag = 0;
       }

       
    }
    // Update is called once per frame
    private void PlayerInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalMovement + orientation.right * horizontalMovement;

        rb.AddForce (moveDirection.normalized * Speed* 10f, ForceMode.Force);
    }

    private void SpeedLimit()
    {
      Vector3 flatVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

      if (flatVelocity.magnitude > Speed)
      {
        Vector3 limitedVelocity = flatVelocity.normalized * Speed;
        rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
      }
    }

}
