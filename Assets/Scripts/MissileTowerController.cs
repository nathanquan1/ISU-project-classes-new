using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTowerController : TowerController
{

    protected override void SetStats()
    {
        Debug.Log("Set Missile Stats");
        damage = 7;
        fireRate = 2f;//3.5dps
        range = 4.0f;
        bulletSpeed = 5f;
    }
}
