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
    public RedEnemyController redEnemyController;

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
        if (SceneManager.GetActiveScene().name == "GameScene") //In case of a glitch check if it's the right scene
        {
            Money = 40;
            Health = 25;
            Level = 1;
            GameRunning = true;
            enemiesSpawned = 0;
        }
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Every time the frame runs timer adds the amount of seconds inbetween the frames
        timer += Time.deltaTime;
        //Debug.Log(GameRunning);
        if (GameRunning && SceneManager.GetActiveScene().name == "GameScene")
        {
            //Debug.log("Game Running.");
            HealthDisplay.text = $"{Health}";
            MoneyDisplay.text = $"Money: ${Money}";
            LevelDisplay.text = $"Level: {Level}";
        }
        //Debug.Log(Health);

        if (Level == 1 && timer > 4) //Starts after 4 seonds so its not instant
        {
            Level1();
        }
        else if (Level == 2)
        {
            Level2();
        }
        else if (Level ==3)
        {
            Level3();
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
        if (Money >= amt) //checked in the other script anyways
        {
            Money -= amt;
        }
    }
    public void Level1()
    {
        if (enemiesSpawned < 10) //1 enemy every 2 seconds (10 enemies max)
        {
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                basicEnemyController.SpawnEnemy();
                timer = 0;
                enemiesSpawned += 1;
            }
        }
        else if (timer >= 35)//Level 1 takes a total of 35 seconds
        {
            //wave 1 finished
            Debug.Log("wave 1 finished");
            Level = 2;
            enemiesSpawned = 0;
            timer = 0;
        }
    }
    public void Level2()
    {
        if (enemiesSpawned < 3) //1 enemy every 2 seconds (3 fast enemies max)
        {
            timer += Time.deltaTime;
            if (timer >= 2)
            {
                fastEnemyController.SpawnEnemy();
                timer = 0;
                enemiesSpawned += 1;
            }
        }
        else if (timer >= 10)
        {
            Level = 3;
            enemiesSpawned = 0;
            timer = 0;
        }
    }
    public void Level3()
    {
        if (enemiesSpawned < 6)//3 basics every second
        {
            timer += Time.deltaTime;
            if (timer >= 1)//every second
            {
                timer = 0;
                enemiesSpawned += 1;
                if (enemiesSpawned < 3)//first 3 will be basic
                {
                    basicEnemyController.SpawnEnemy();
                }
                else //last 3 will be fast
                {
                    fastEnemyController.SpawnEnemy();
                }
            }
        }
    }

}
