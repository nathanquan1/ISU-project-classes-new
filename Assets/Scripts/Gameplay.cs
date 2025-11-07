using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
public class Gameplay : MonoBehaviour
{
    public SceneSwitcher sceneSwitcher;
    public bool GameRunning;

    public EnemyController enemyController;
    
    public BasicEnemyController basicEnemyController;
    public FastEnemyController fastEnemyController;
    public AlienEnemyController alienEnemyController;
    

    public TextMeshProUGUI HealthDisplay;
    public TextMeshProUGUI MoneyDisplay;
    public TextMeshProUGUI LevelDisplay;
    private int Money;
    private int Health;
    private int Level;
    public float timer;

    private int enemiesSpawned;
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene") //In case of a glitch
        {
            Money = 100;
            Health = 20;
            Level = 1;
            GameRunning = true;
            enemiesSpawned = 0;
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
            HealthDisplay.text = $"{Health}";
            MoneyDisplay.text = $"Money: ${Money}";
            LevelDisplay.text = $"Level: {Level}";
        }
        //Debug.Log(Health);

        if (Level == 1)
        {
            Level1();
        }
        else if (Level ==2)
        {
            Level2();
        }
    }

    public void Level1()
    {
        
        if (enemiesSpawned < 10 && timer > 2) //1 enemy every 2 seconds (10 enemies max)
        {
            basicEnemyController.SpawnEnemy();
            timer = 0;
            enemiesSpawned += 1;
        }
        else if (enemiesSpawned >= 10 && timer>35)//35 seconds until next wave
        {
            //wave 1 finished
            Debug.Log("wave 1 finished");
            Level = 2;
            enemiesSpawned = 0;
        }
    }
    public void Level2()
    {
        if (enemiesSpawned < 3 && timer > 2) //1 enemy every 2 seconds (3 fast enemies max)
        {
            fastEnemyController.SpawnEnemy();
            timer = 0;
            enemiesSpawned += 1;
        }
        else if (enemiesSpawned >= 3)
        {
            //wave 2 finished
        }
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
    public int GetMoney()
    {
        return Money;
    }
    public void SpendMoney(int amt)
    {
        if (Money>amt) //checked in the other script anyways
        {
            Money -= amt;
        }
    }
    
}
