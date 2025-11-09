using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonTowerPlacement : TowerPlacement
{
    // Update is called once per frame
    protected override void Start()
    {
        base.Start();
        this.Price = 30;
    }
}
