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
    public GameObject helpMenu;
    public Slider volumeSlider;
    public AudioClip MainMenuTheme;
    public AudioSource sound;
    public AudioSource music;

    //public Gameplay gameplay;
    void Start()
    {
        OpenPlayMenu();

        float savedMusicVolume = PlayerPrefs.GetFloat("Music", 0.5f);
        float savedSFXVolume = PlayerPrefs.GetFloat("SFX", 0.5f);
        music.volume = savedMusicVolume;
        sound.volume = savedSFXVolume; // Sound effects not added yet

        music.PlayOneShot(MainMenuTheme); // Music looped
        volumeSlider.value = savedSFXVolume; // Set the slider to match the saved volume
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
        helpMenu.SetActive(false);
    }
    public void ToggleSettings()
    {
        settingsMenu.SetActive(!settingsMenu.activeSelf);
    }

    public void OpenLoadoutMenu()
    {
        settingsMenu.SetActive(false);
        playMenu.SetActive(false);

        helpMenu.SetActive(true);
    }

    public void SetVolume(float value)
    {
        music.volume = value;
        sound.volume = value;

        PlayerPrefs.SetFloat("Music", value);
        PlayerPrefs.SetFloat("SFX", value);
        PlayerPrefs.Save();
    }


}
