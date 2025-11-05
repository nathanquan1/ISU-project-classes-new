using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : EnemyController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _x = transform.position.x;
        _y = transform.position.y;
    }
    protected override void SetStats()
    {
        this._speed = 0.5f;
        this._damage = 1;
        this._health = 10;
    }
}
