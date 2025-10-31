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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameRunning)
        {
            //
            enemyController.SpawnEnemy();

        }
    }
    public void StartGame()
    {
        //i think it needs to be static for it to be used in other file
        GameRunning = true;

    }
    public void TakeDamage(int damage)
    {
        
    }
    public void EndGame()
    {
        GameRunning = false;
        menuController.Homescreen();
    }
}
