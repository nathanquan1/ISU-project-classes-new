using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SettingsMenu : MonoBehaviour
{
    public GameObject SettingsPanel; 
    public Slider Volume;
    public MenuController MenuController; 
    public TextMeshProUGUI VolumeText;


    void Start()
    {
        //Sets volume to the slider volume level by calling the setVolume function
        Volume.onValueChanged.AddListener(MenuController.SetVolume);
        VolumeText.text = "Volume: " + Mathf.RoundToInt(MenuController.music.volume*100).ToString()+"%";
    }
    void Update()
    {
        VolumeText.text = "Volume: " + Mathf.RoundToInt(MenuController.music.volume*100).ToString()+"%";
    }

    public void ToggleSettings()
    {
        //Toggles settings panel on/off when clicked
        SettingsPanel.SetActive(!SettingsPanel.activeSelf); 

    }
}
