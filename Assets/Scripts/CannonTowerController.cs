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
    }
}
