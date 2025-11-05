using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
public class Gameplay : MonoBehaviour
{
    // Start is called before the first frame update
    public MenuController menuController;
    public bool GameRunning;
    public EnemyController enemyController;
    public TextMeshProUGUI HealthDisplay;
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
        if (GameRunning)
        {
            HealthDisplay.text = $"HP: {Health}";
        }
        //Debug.Log(Health);
    }
    public void StartGame()
    {
        Debug.Log("Game Started");
        GameRunning = true;
        Money = 10;
        Health = 100;
        Level = 1;

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
        //menuController.Homescreen();
    }
    public int GetHealth()
    {
        return Health;
    }
}
