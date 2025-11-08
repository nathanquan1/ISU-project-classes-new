using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunTowerController : TowerController
{
    // Start is called before the first frame update

    protected override void SetStats()
    {
        damage = 1;
        fireRate = 4.0f;
        range = 3.0f;
        bulletSpeed = 8f;
    }
}
