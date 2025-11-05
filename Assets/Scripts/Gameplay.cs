using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            Money = 100;
            Health = 20;
            Level = 1;
            GameRunning = true;
        }
        // The UI is also refreshed initially to avoid placeholder text residue.
        if (HealthDisplay) HealthDisplay.text = $"HP: {Health}";
        if (MoneyDisplay)  MoneyDisplay.text  = $"Money: ${Money}";
        if (LevelDisplay)  LevelDisplay.text  = $"Level: {Level}";
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameRunning);
        // Keep the UI synchronized with the current values, regardless of whether it's in GameRunning (only in GameScene).
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            if (HealthDisplay) HealthDisplay.text = $"HP: {Health}";
            if (MoneyDisplay)  MoneyDisplay.text  = $"Money: ${Money}";
            if (LevelDisplay)  LevelDisplay.text  = $"Level: {Level}";
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
        if (!GameRunning) return;        // Prevent repeated triggering
        GameRunning = false;
        if (sceneSwitcher != null) sceneSwitcher.Homescreen();
    }
    public int GetHealth()
    {
        return Health;
    }
    public void Level1()
    {
        
    }
}
