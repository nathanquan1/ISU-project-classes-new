using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject deckMenu;
    void Start()
    {
        MainMenu();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MainMenu()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        deckMenu.SetActive(false);
    }
    public void Settings()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
        deckMenu.SetActive(false);
    }

    public void DeckMenu()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(false);
        
        deckMenu.SetActive(true);
    }
}
