using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject playMenu;
    public GameObject settingsMenu;
    public GameObject deckMenu;

    public Gameplay gameplay;
    void Start()
    {
        OpenPlayMenu();
    }

    // Update is called once per frame
    void Update()
    {

    }
    // SWITCH UI:
    public void OpenPlayMenu()
    {
        playMenu.SetActive(true);
        settingsMenu.SetActive(false);
        deckMenu.SetActive(false);
    }
    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
        playMenu.SetActive(false);
        deckMenu.SetActive(false);
    }

    public void OpenDeckMenu()
    {
        settingsMenu.SetActive(false);
        playMenu.SetActive(false);

        deckMenu.SetActive(true);
    }
    //SWITCH SCENE:
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
        //variable : public Gameplay gameplay;
        gameplay.StartGame();
    }
    
    public void Homescreen()
    {
        SceneManager.LoadScene("MainScene");
    }
}
