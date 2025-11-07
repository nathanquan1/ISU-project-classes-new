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
    protected override void Place()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cannonTowerController.PlaceTower(mousePos.x, mousePos.y);
    }
}
