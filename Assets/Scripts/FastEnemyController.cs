using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemyController : EnemyController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        Debug.Log("Fast Start");
        base.Start();
        _damage = 1;
        _health = 5;
        _speed = 1.5f; //not working for some reason
        
    }
    // Update is called once per frame
    void Update()
    {

    }

}
