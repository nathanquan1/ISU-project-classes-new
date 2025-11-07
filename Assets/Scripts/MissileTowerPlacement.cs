using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MissileTowerPlacement : TowerPlacement
{
    protected override void Start()
    {
        base.Start();
        this.Price = 100;
    }
    protected override void Place()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        missileTowerController.PlaceTower(mousePos.x, mousePos.y);
    }
}
