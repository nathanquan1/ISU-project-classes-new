using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienEnemyController : EnemyController
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
        Debug.Log("Set Alien Stats");
        this._damage = 3;
        this._health = 60;
        this._speed = 0.5f;
        this._value = 30;
        this.spawned = true;
    }
}
