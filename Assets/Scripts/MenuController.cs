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
        music.volume = PlayerPrefs.GetFloat("Music");//set volume to what it was set to last time you played
        sound.volume = PlayerPrefs.GetFloat("SFX"); //Sound effects slider not added yet

        music.PlayOneShot(MainMenuTheme); // Music looped
        volumeSlider.value = music.volume*10; // Set the slider to match the saved volume
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
        music.volume = value*0.1f;
        sound.volume = value*0.1f;

        PlayerPrefs.SetFloat("Music", music.volume);//stores 
        PlayerPrefs.SetFloat("SFX", sound.volume);
        PlayerPrefs.Save();
    }


}
