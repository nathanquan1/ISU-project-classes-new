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
        Debug.Log("Set Alien Stats");
        _damage = 0;
        _health = 60;
        _speed = 0.6f;
        this.spawned = true;
    }
}
