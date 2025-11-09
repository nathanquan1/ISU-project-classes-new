using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienEnemyController : EnemyController
{
    // Start is called before the first frame update
    private float _defense;

    protected override void Start()
    {
        base.Start();
        ChangeDirection("E");
        SetStats();
    }

    protected override void SetStats()
    {
        Debug.Log("Set Alien Stats");
        this._damage = 20;
        this._health = 80;
        this._speed = 0.5f;
        this._value = 30;
        this._defense = 0.7f;
    }

    protected override void TakeDamage(float damage)
    {
        base.TakeDamage(damage * _defense);
    }
}
