using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SettingsMenu : MonoBehaviour
{
    public GameObject SettingsPanel; 
    public Slider MusicVolume;
    public Slider SoundVolume;
    public MenuController MenuController; 
    public TextMeshProUGUI MusicVolumeText;
    public TextMeshProUGUI SoundVolumeText;


    void Start()
    {
        //Sets volume to the slider volume level by calling the setVolume function
        MusicVolume.onValueChanged.AddListener(MenuController.SetMusicVolume);
        SoundVolume.onValueChanged.AddListener(MenuController.SetSoundVolume);
        MusicVolumeText.text = "Music: " + Mathf.RoundToInt(MenuController.music.volume*1000).ToString()+"%";
        SoundVolumeText.text = "SFX: " + Mathf.RoundToInt(MenuController.sound.volume*1000).ToString() + "%";
    }
    void Update()
    {
        MusicVolumeText.text = "Music: " + Mathf.RoundToInt(MenuController.music.volume*1000).ToString()+"%";
        SoundVolumeText.text = "SFX: " + Mathf.RoundToInt(MenuController.sound.volume*1000).ToString()+"%";
    }

    public void ToggleSettings()
    {
        //Toggles settings panel on/off when clicked
        SettingsPanel.SetActive(!SettingsPanel.activeSelf); 

    }
}
