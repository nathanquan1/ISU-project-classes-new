using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunTowerController : TowerController
{
    // Start is called before the first frame update

    protected override void SetStats()
    {
        damage = 1;
    }
}
