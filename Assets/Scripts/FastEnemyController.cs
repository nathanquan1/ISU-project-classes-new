using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemyController : EnemyController
{
    // Start is called before the first frame update

    protected override void Start()
    {
        base.Start();
        _x = transform.position.x;
        _y = transform.position.y;
    }
    
    // Update is called once per frame
    /*
    void Update()
    {
        base.Update();
    }
    */
    protected override void SetStats()
    {
        _damage = 1;
        _health = 5;
        _speed = 1.5f; 
    }
}
