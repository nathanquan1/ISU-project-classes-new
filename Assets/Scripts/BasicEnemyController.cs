using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : EnemyController
{
    // Start is called before the first frame update
    [SerializeField] private int _cfgDamage = 2;
    [SerializeField] private float _cfgHealth = 10f;
    [SerializeField] private float _cfgSpeed = 1.00f;
    [SerializeField] private int _cfgValue = 10;

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
        this._damage = _cfgDamage;
        this._health = _cfgHealth;
        this._speed = _cfgSpeed;
        this._value = _cfgValue;
    }
}
