using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables

    private Rigidbody2D rb;

    //speed
    public float runSpeed = 20f;
    float moveLimiter = 0.7f;

    //facing
    public bool isFacingRight;

    //axis
    private Vector2 moveInput;
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Start()
    {
        
    }

    
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        if (moveInput.x != 0)
            CheckDirectionToFace(moveInput.x > 0);
    }

    void FixedUpdate()
    {
        if (moveInput.x != 0 && moveInput.y != 0) 
        {
            moveInput.x *= moveLimiter;
            moveInput.y *= moveLimiter;
        }

        rb.velocity = new Vector2(moveInput.x * runSpeed, moveInput.y * runSpeed);
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
