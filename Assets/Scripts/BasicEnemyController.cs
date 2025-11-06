using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : EnemyController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this._x = transform.position.x;
        this._y = transform.position.y;
        ChangeDirection("E");
        SetStats();
    }
    protected override void SetStats()
    {
        Debug.Log("Set Basic Stats");
        this._damage = 2;
        this._health = 10;
        this._speed = 1.00f;
        this._value = 10;
        this.spawned = true;
    }

}
