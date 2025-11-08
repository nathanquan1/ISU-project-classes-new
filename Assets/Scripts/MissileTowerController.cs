using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTowerController : TowerController
{

    protected override void SetStats()
    {
        Debug.Log("Set Missile Stats");
        damage = 8;
        fireRate = 2;//4dps
        range = 5;
        bulletSpeed = 5f;
    }
}
