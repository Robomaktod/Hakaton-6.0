using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Variables
    public SpawnMushrooms mushroom;
    
    private List<FadeObject> fadeObjects = new List<FadeObject>();

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

    //Mushrooms
    public int mushroomCount;

    //axis
    [SerializeField] private Vector2 moveInput;
    
    public AudioSource footSteps;
    
    AudioSource mushroomsCollect;
    public GameManager gm;


    #endregion


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        footSteps = GetComponent<AudioSource>();
        mushroomsCollect = GetComponent<AudioSource> ();
    }

    
    void Update()
    {
        if (playerInside)
        {
            timeInArea += Time.deltaTime;
            if (timeInArea >= 0.5f)
            {
                gm.GoToMenu();
                EnemyChasing[] enemies = GameObject.FindObjectsOfType<EnemyChasing>() ;
                foreach (EnemyChasing beb in enemies)
                {
                    Destroy(beb.gameObject);
                }
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
            FadeObject fadeObject = collision.GetComponent<FadeObject>();
            if (fadeObject != null)
            {
                fadeObject.doFade = true;
                fadeObjects.Add(fadeObject);
            }
        }

        if (collision.CompareTag("mushroom"))
        {
            mushroomCount++;
            Destroy(collision.gameObject);
            mushroom.Spawn();

            
            mushroomsCollect.Play ();
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
            FadeObject fadeObject = collision.GetComponent<FadeObject>();
            if (fadeObject != null)
            {
                fadeObject.doFade = false;
                fadeObjects.Remove(fadeObject);
            }
        }
    }



    void steps()
    {
        if((moveInput.x!=0) || (moveInput.y!=0)){
            
            footSteps.enabled = true;
        }
        else
        {
            footSteps.enabled = false;
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

       
        steps();
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
