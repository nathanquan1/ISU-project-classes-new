using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
public class Gameplay : MonoBehaviour
{
    // Start is called before the first frame update
    public MenuController menuController;
    public bool GameRunning = false;
    public EnemyController enemyController;
    public TextMeshProUGUI HealthDisplay;
    private int Money;
    private int Health;
    private int Level;

    void Start()
    {
        Health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        HealthDisplay.text = $"HP: {Health}";
        //Debug.Log(Health);
    }
    public void StartGame()
    {
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
        menuController.Homescreen();
    }
}
