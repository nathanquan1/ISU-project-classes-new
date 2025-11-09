using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunTowerController : TowerController
{
    // Start is called before the first frame update

    protected override void SetStats()
    {
        Debug.Log("Set MG Stats");
        damage = 0.6f;
        fireRate = 0.2f;//3dps
        range = 2.8f;
        bulletSpeed = 9f;
    }
}
