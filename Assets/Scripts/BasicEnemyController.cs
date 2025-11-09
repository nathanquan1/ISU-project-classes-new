using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : EnemyController
{


    protected override void Start()
    {
        base.Start();
        ChangeDirection("E");
        SetStats();
    }
    protected override void SetStats()
    {
        Debug.Log("Set Basic Stats");
        this._damage = 2;
        this._health = 7;
        this._speed = 1;
        this._value = 7;
    }
}
