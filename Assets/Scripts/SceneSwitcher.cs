using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    public Gameplay gameplay;

    private static bool _bootedToMain = false;

    void Start()
    {
        if (!_bootedToMain && SceneManager.GetActiveScene().name != "MainScene")
        {
            _bootedToMain = true;
            SceneManager.LoadScene("MainScene");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayGame()
    {
        _bootedToMain = true;
        SceneManager.LoadScene("GameScene");
        //variable : public Gameplay gameplay;
        //gameplay.StartGame();
    }
    
    public void Homescreen()
    {
        _bootedToMain = true;
        SceneManager.LoadScene("MainScene");
    }
}
