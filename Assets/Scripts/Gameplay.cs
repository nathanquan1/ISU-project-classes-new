using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
public class Gameplay : MonoBehaviour
{
    public EnemyController enemyController;
    public BasicEnemyController basicEnemyController;
    public FastEnemyController fastEnemyController;
    public AlienEnemyController alienEnemyController;
    public RedEnemyController redEnemyController;
    private int enemiesSpawned;

    public SceneSwitcher sceneSwitcher;//script
    public bool GameRunning;
    public TextMeshProUGUI HealthDisplay;
    public TextMeshProUGUI MoneyDisplay;
    public TextMeshProUGUI LevelDisplay;
    private int Money;
    private int Health;
    private int Level;
    public float timer;

    public AudioClip GameSceneTheme;
    public AudioSource sound;
    public AudioSource music;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "GameScene") //So this doesn't run in the main menu
        {
            Money = 40;
            Health = 25;
            Level = 1;
            GameRunning = true;
            enemiesSpawned = 0;
        }
        timer = 0;
        float MusicVolume = PlayerPrefs.GetFloat("Music", 0.5f);
        float SFXVolume = PlayerPrefs.GetFloat("SFX", 0.5f);
        music.volume = MusicVolume;
        sound.volume = SFXVolume;
        music.PlayOneShot(GameSceneTheme);//loop
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


        if (Level == 1 && timer > 4) //Starts after 4 seonds so its not instant
        {
            Level1();
        }
        else if (Level == 2)
        {
            Level2();
        }
        else if (Level == 3)
        {
            Level3();
        }
        else if (Level == 4)
        {
            Level4();
        }
        else if (Level == 5)
        {
            Level5();
        }
        else
        {
            Win();
        }
    }

    public void EndGame()
    {
        GameRunning = false;
        sceneSwitcher.Homescreen();

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

    public int GetHealth()
    {
        return Health;
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
        else if (enemyController.getEnemies() == 0) //When they all die start next wave
        {
            //reset
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
        else if (enemyController.getEnemies() == 0)//wait 10 seconds AFTER all enemies spawn
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
        else if (enemyController.getEnemies() == 0)
        {
            Level = 4;
            enemiesSpawned = 0;
            timer = 0;
        }
    }
    public void Level4()
    {
        if (enemiesSpawned < 3)
        {
            if (timer >= 2)
            {
                timer = 0;
                enemiesSpawned += 1;
                redEnemyController.SpawnEnemy();
            }
        }
        else if (enemyController.getEnemies() == 0)
        {
            Level = 5;
            enemiesSpawned = 0;
            timer = 0;
        }
    }
    public void Level5()
    {
        if (enemiesSpawned < 2 && timer < 2)
        {
            timer = 0;
            alienEnemyController.SpawnEnemy();
            enemiesSpawned += 1;
        }
        else if (enemyController.getEnemies() == 0)
        {
            //win
            Win();
        }
    }

    public void Win()
    {
        Debug.Log("You Win!");
        GameRunning = false;
    }
}
