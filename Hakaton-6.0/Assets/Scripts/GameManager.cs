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

    GameObject player;

    void Start()
    {
        player.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        GamePanel.SetActive(true);
        Shop.SetActive(false);
        Options.SetActive(false);
        Home.SetActive(false);
        player.SetActive(true);
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

    }
}
