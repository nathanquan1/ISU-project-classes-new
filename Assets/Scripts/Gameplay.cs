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

    // Separate monster spawn timer and wave interval timer to avoid confusion caused by using the "timer" function for multiple purposes.
    private float spawnTimer;
    private float waveGapTimer;

    // Simple wave status marking to avoid repeated entry
    private bool wave1Started;
    private bool wave2Started;

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

        // Initialize new timers and flags
        spawnTimer = 0f;
        waveGapTimer = 0f;
        wave1Started = false;
        wave2Started = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Increase timer every frame by right amt
        timer += Time.deltaTime;
        //Debug.Log(GameRunning);
        if (GameRunning && SceneManager.GetActiveScene().name == "GameScene")
        {
            //Debug.log("Game Running.");
            if (HealthDisplay != null) HealthDisplay.text = $"{Health}";
            if (MoneyDisplay != null) MoneyDisplay.text = $"Money: ${Money}";
            if (LevelDisplay != null) LevelDisplay.text = $"Level: {Level}";
        }
        //Debug.Log(Health);

        if (Level == 1 && timer > 5) //timer>5 so it doesnt start the game right after you press play
        {
            Level1();
        }
        else if (Level == 2)
        {
            Level2();
        }
    }

    public void Level1()
    {
        // The system has been marked as having entered the first phase to prevent accidental triggering of other start logic from external sources.
        if (!wave1Started) wave1Started = true;

        if (enemiesSpawned < 10) //1 enemy every 2 seconds (10 enemies max)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= 2f)
            {
                if (basicEnemyController != null)
                {
                    basicEnemyController.SpawnEnemy();
                }
                //timer = 0;  // No longer reuse timers as monster spawn timers
                spawnTimer = 0f;
                enemiesSpawned += 1;
            }
        }
        else if (enemiesSpawned >= 10) //35 seconds until next wave
        {
            waveGapTimer += Time.deltaTime;
            if (waveGapTimer >= 35f)
            {
                //wave 1 finished
                Debug.Log("wave 1 finished");
                Level = 2;
                enemiesSpawned = 0;
                // Reset the local timer before entering the next wave
                spawnTimer = 0f;
                waveGapTimer = 0f;
            }
        }
    }
    public void Level2()
    {
        if (!wave2Started) wave2Started = true;

        if (enemiesSpawned < 3) //1 enemy every 2 seconds (3 fast enemies max)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= 2f)
            {
                if (fastEnemyController != null)
                {
                    fastEnemyController.SpawnEnemy();
                }
                spawnTimer = 0f;
                enemiesSpawned += 1;
            }
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
        if (!GameRunning) return;
        GameRunning = false;
        if (sceneSwitcher != null)
        {
            sceneSwitcher.Homescreen();
        }
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
        if (Money>=amt) //checked in the other script anyways
        {
            Money -= amt;
        }
    }
    
}
