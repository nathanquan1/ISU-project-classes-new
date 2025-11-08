using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTowerController : TowerController
{
    // Start is called before the first frame update
    //public GameObject tower;
    protected override void SetStats()
    {
        damage = 1;
        fireRate = 0.75f;
        range = 3.5f;
        bulletSpeed = 6f;
    }
}
