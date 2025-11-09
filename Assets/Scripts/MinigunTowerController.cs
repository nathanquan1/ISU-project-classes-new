using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunTowerController : TowerController
{
    // Start is called before the first frame update

    protected override void SetStats()
    {
        Debug.Log("Set MG Stats");
        damage = 0.4f;
        fireRate = 0.1f;//4dps
        range = 2.8f;
        bulletSpeed = 9f;
    }
}
