using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject playMenu;
    public GameObject settingsMenu;
    public GameObject loadoutMenu;

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
        loadoutMenu.SetActive(false);
    }
    public void ToggleSettings()
    {
        settingsMenu.SetActive(!settingsMenu.activeSelf);
    }

    public void OpenLoadoutMenu()
    {
        settingsMenu.SetActive(false);
        playMenu.SetActive(false);

        loadoutMenu.SetActive(true);
    }

}
