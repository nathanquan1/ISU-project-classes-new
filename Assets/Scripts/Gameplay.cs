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
    public float timer;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            Money = 100;
            Health = 20;
            Level = 1;
            GameRunning = true;
        }
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Increase timer every frame by right amt
        timer += Time.deltaTime; 
        //Debug.Log(GameRunning);
        if (GameRunning && SceneManager.GetActiveScene().name == "GameScene")
        {
            //Debug.Log("Game Running.");
            HealthDisplay.text = $"HP: {Health}";
            MoneyDisplay.text = $"Money: ${Money}";
            LevelDisplay.text = $"Level: {Level}";
        }
        //Debug.Log(Health);
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
    public void Level1()
    {
        if (timer <1)
        {
            //enemyController.SpawnEnemy();
            //import fast enemy controller + others
        }
    }
}
