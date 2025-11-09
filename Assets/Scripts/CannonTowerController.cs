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
        damage = 1;//1dps
        fireRate = 1;
        range = 3.5f;
        bulletSpeed = 7f;
    }
}
