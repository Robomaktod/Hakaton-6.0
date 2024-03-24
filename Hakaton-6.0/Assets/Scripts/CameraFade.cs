using UnityEngine;

public class FadeObject2D : MonoBehaviour
{
    public FadeObject fadeObject;
    public GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Vector2 dir = player.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject == player)
            {
                if (fadeObject != null)
                {
                    fadeObject.doFade = false;
                }
            }
            else
            {
                fadeObject = hit.collider.GetComponent<FadeObject>();
                if (fadeObject != null)
                {
                    fadeObject.doFade = true;
                    fadeObject.GetComponent<Collider2D>().enabled = false;
                }
            }
        }
    }

    
}
