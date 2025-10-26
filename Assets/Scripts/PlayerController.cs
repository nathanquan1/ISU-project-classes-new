using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    //Might be wrong:
    public int _health;
    public int _energy;

    public PlayerController()
    {
        this._health = 10;
        this._energy = 0;
    }
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class EnemyController : PlayerController
{
    //This might be suppsoed to be in another file 
}