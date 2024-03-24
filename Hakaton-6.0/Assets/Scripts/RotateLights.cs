using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLights : MonoBehaviour
{
    public Transform player;
    Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
        rb.rotation = angle; 
        direction.Normalize();
    }
  

}
