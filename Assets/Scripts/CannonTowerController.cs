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
        damage = 2;//1dps
        fireRate = 4f;
        range = 3.5f;
        bulletSpeed = 6f;
    }
}
