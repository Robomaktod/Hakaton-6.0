using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyChasing : MonoBehaviour
{
    private Rigidbody2D rb;
    public float runSpeed = 5f;
    public Transform player;

    private bool isFacingRight = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        Chase();
        if (Vector2.Distance(transform.position, player.transform.position) > 15)
        {
            Destroy(this.gameObject);
        }
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, runSpeed * Time.deltaTime);
    }

    private void Turn()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        isFacingRight = !isFacingRight;
    }

}
