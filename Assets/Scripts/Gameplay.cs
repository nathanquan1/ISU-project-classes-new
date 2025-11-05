using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

using UnityEngine.SceneManagement;
public class Gameplay : MonoBehaviour
{
    // Start is called before the first frame update
    public SceneSwitcher sceneSwitcher;
    public bool GameRunning;
    public EnemyController enemyController;
    public TextMeshProUGUI HealthDisplay;
    public TextMeshProUGUI MoneyDisplay;
    public TextMeshProUGUI LevelDisplay;
    private int Money;
    private int Health;
    private int Level;

    void Start()
    {
        Health = 100;
        GameRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameRunning && SceneManager.GetActiveScene().name =="GameScene")
        {
            HealthDisplay.text = $"HP: {Health}";
            MoneyDisplay.text = $"Money: ${Money}";
            LevelDisplay.text = $"Level: {Level}";
        }
        //Debug.Log(Health);
    }
    public void StartGame()
    {
        Debug.Log("Game Started");
        Money = 10;
        Health = 100;
        Level = 1;
        GameRunning = true;
    }
    public void TakeDamage(int damage)
    {
        if (Health - damage <= 0)
        {
            Health = 0;
            EndGame();
        }
        else
        {
            Health -= damage;
        }
    }
    public void EndGame()
    {
        GameRunning = false;
        sceneSwitcher.Homescreen();
    }
    public int GetHealth()
    {
        return Health;
    }
}
