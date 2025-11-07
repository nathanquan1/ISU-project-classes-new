using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject playMenu;
    public GameObject settingsMenu;
    public GameObject loadoutMenu;
    public AudioClip MainMenuTheme;
    public AudioSource sound;
    public AudioSource music;

    //public Gameplay gameplay;
    void Start()
    {
        OpenPlayMenu();

        music.PlayOneShot(MainMenuTheme); // Music looped
        music.volume = 0.0f;
        sound.volume = 0.0f;
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

    public void SetVolume(float value)
    {
        music.volume = value;
        sound.volume = value;
    }


}
