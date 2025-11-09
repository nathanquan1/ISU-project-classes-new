using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemyController : EnemyController
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
        this._damage = 5;
        this._health = 100;
        this._speed = 0.3f;
        this._value = 50;
    }

    public override void SpawnEnemy()
    {
        //this.spawned = true;
        base.SpawnEnemy();
        
    }
}
