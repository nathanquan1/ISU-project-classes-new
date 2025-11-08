using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTowerController : TowerController
{
    // Start is called before the first frame update
    //public GameObject tower;
    protected override void SetStats()
    {
        Debug.Log("Set Cannon Stats");
        damage = 3;//1.5dps
        fireRate = 2;
        range = 3.2f;
        bulletSpeed = 7f;
    }
}
