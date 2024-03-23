using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    [SerializeField] private Rigidbody2D rb;
    public Joystick joystick;
    public bool PC = true;
    //speed
    public float runSpeed = 6f;

    //facing
    public bool isFacingRight;

    //axis
    [SerializeField] private Vector2 moveInput;
    #endregion


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        //
        if (moveInput.x != 0)
            CheckDirectionToFace(moveInput.x > 0);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        //perform movement
        if (PC)
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            moveInput.x = joystick.Direction.x;
            moveInput.y = joystick.Direction.y;
        }

       
        rb.velocity = moveInput.normalized * runSpeed;
    }


    private void Turn()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        isFacingRight = !isFacingRight;
    }


    public void CheckDirectionToFace(bool isMovingRight)
    {
        if (isMovingRight != isFacingRight)
            Turn();
    }

}
