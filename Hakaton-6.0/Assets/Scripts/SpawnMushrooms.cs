using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMushrooms : MonoBehaviour
{
    public GameObject mushroom;
    public Vector3 randPos;
    public int mushroomCount;

    public float checkRadius = 1f;
    public LayerMask layerMask;

    void Start()
    {
        for (int i = 0; i < mushroomCount; i++)
        {
            if ((Physics.OverlapSphere(randPos, checkRadius, layerMask)).Length == 0) 
            {
                randPos = new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f), 0);
            }

            Instantiate(mushroom, randPos, Quaternion.identity);
        }
    }

    
}
