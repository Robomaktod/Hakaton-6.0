using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spawnObject;
    public Vector3 randPos;
    private bool canSpawn = true;

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
        WaitForSeconds wait = new WaitForSeconds(Random.Range(10, 15));

        while (canSpawn)
        {
            randPos = new Vector3(Random.Range(-15f, 15f), Random.Range(-15f, 15f), 0);
            yield return wait;
            Instantiate(spawnObject, randPos + transform.position, Quaternion.identity);
        }
    }

}
