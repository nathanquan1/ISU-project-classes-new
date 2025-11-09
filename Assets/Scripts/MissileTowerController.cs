using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTowerController : TowerController
{

    protected override void SetStats()
    {
        Debug.Log("Set Missile Stats");
        damage = 28;
        fireRate = 4;//7dps
        range = 5;
        bulletSpeed = 5f;
    }
}
