using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    public FadeObject fadeObject;

    [SerializeField] private Rigidbody2D rb;
    public Joystick joystick;
    public bool PC = true;
    //speed
    public float runSpeed = 6f;

    //facing
    public bool isFacingRight;

    //player death
    public bool playerInside;
    public float timeInArea;

    //axis
    [SerializeField] private Vector2 moveInput;
    #endregion


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (playerInside)
        {
            timeInArea += Time.deltaTime;
            if (timeInArea >= 0.5f)
            {
                Destroy(gameObject);
            }
        }

        if (moveInput.x != 0)
            CheckDirectionToFace(moveInput.x > 0);
    }

    private void FixedUpdate()
    {
        Move();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("light"))
        {
            playerInside = true; 
        }

        if (collision.CompareTag("tree"))
        {
            fadeObject = collision.GetComponent<FadeObject>();
            fadeObject.doFade = true;
            fadeObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("light"))
        {
            playerInside = false;
            timeInArea = 0f;
        }

        if (collision.CompareTag("tree"))
        {
            fadeObject.doFade = false;
        }
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
