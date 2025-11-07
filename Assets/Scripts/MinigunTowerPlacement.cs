using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MinigunTowerPlacement : TowerPlacement
{
    // Update is called once per frame
    protected override void Start()
    {
        base.Start();
        Price = 70;
    }
    protected override void Place()
    {
        Debug.Log("MG place");
        //towerPreview.SetActive(_selected);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        minigunTowerController.PlaceTower(mousePos.x, mousePos.y);
    }
}
