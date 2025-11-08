using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienEnemyController : EnemyController
{
    // Start is called before the first frame update
    private float _defense;

    [SerializeField] private int _cfgDamage = 3;
    [SerializeField] private float _cfgHealth = 60f;
    [SerializeField] private float _cfgSpeed = 0.5f;
    [SerializeField] private int _cfgValue = 30;
    [SerializeField] private float _cfgDefense = 0.7f;

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
        this._damage = _cfgDamage;
        this._health = _cfgHealth;
        this._speed = _cfgSpeed;
        this._value = _cfgValue;
        this._defense = _cfgDefense;
    }

    protected override void TakeDamage(float damage)
    {
        base.TakeDamage(damage * _defense);
    }
}
