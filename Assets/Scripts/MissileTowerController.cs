using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTowerController : TowerController
{

    protected override void SetStats()
    {
        damage = 2;
        fireRate = 1.0f;
        range = 4.0f;
        bulletSpeed = 7f;
    }
}
