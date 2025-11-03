using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienEnemyController : EnemyController
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
        _damage = 50;
        _health = 60;
        _speed = 0.6f; 
    }
}
