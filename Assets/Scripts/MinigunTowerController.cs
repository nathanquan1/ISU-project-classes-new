using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunTowerController : TowerController
{
    // Start is called before the first frame update

    protected override void SetStats()
    {
        Debug.Log("Set MG Stats");
        damage = 0.5f;
        fireRate = 0.1f;//5dps
        range = 3.0f;
        bulletSpeed = 8f;
    }
}
