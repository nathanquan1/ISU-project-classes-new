using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemyController : EnemyController
{
    // Start is called before the first frame update

    protected override void Start()
    {
        base.Start();

        ChangeDirection("E");
        SetStats();
    }

    protected override void SetStats()
    {
        Debug.Log("Set Fast Stats");
        this._damage = 1;
        this._health = 6;
        this._speed = 1.7f;
        this._value = 10;
    }
}
