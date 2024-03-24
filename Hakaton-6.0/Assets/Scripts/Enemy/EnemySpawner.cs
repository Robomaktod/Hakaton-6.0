using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] spawnObject;
    public Vector3 randPos;
    private bool canSpawn = true;
    public Vector2 timeRange;
    public int zoneRange = 15;

    void Start()
    {
        StartCoroutine(Spawner());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 15);
    }


    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(Random.Range(timeRange.x, timeRange.y));

        while (canSpawn)
        {
            randPos = new Vector3(Random.Range(-zoneRange, zoneRange), Random.Range(-zoneRange, zoneRange), 0);
            yield return wait;

            int rand = Random.Range(0, spawnObject.Length);
            GameObject spawn = spawnObject[rand];
            Instantiate(spawn, randPos + transform.position, Quaternion.identity);
        }
    }

}
