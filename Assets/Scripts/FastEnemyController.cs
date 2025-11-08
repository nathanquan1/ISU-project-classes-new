using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemyController : EnemyController
{
    // Start is called before the first frame update
    [SerializeField] private int _cfgDamage = 1;
    [SerializeField] private float _cfgHealth = 5f;
    [SerializeField] private float _cfgSpeed = 1.5f;
    [SerializeField] private int _cfgValue = 20;

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
        Debug.Log("Set Fast Stats");
        this._damage = _cfgDamage;
        this._health = _cfgHealth;
        this._speed = _cfgSpeed;
        this._value = _cfgValue;
    }

    public override void SpawnEnemy()
    {
        //this.spawned = true;
        base.SpawnEnemy();
        
    }
}
