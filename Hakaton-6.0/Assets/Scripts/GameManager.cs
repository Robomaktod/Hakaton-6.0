using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Shop;
    public GameObject Options;
    public GameObject Home;
    public GameObject GamePanel;

    public GameObject player;

    void Start()
    {
        player.gameObject.SetActive(false);
        Nen(false);

    }

    public void StartGame()
    {
        GamePanel.SetActive(true);
        Shop.SetActive(false);
        Options.SetActive(false);
        Home.SetActive(false);
        player.SetActive(true);
        Nen(true);
    }

    public void OpenSettings()
    {
        Options.SetActive(true);
        Home.SetActive(false);
    }

    public void CloseSettings()
    {
        Options.SetActive(false);
        Home.SetActive(true);
    }

    public void GoToMenu()
    {
        GamePanel.SetActive(false);
        Home.SetActive(true);
        Options.SetActive(false);
        Shop.SetActive(false);
        player.gameObject.SetActive(false);


    }

    void Nen(bool a)
    {
        EnemyChasing[] enemies = GameObject.FindObjectsOfType<EnemyChasing>();
        foreach (EnemyChasing beb in enemies)
        {
            beb.gameObject.SetActive(a);
        }
    }
}
