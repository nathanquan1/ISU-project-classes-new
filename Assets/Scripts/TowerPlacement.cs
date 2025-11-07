using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public Gameplay gameplay;
    public GameObject towerPreview;
    public TowerController towerController;
    private bool _selected = false;
    public void togglePlacing()
    {
        _selected = !_selected;
    }
    public void Start()
    {
        towerPreview.SetActive(false);
    }
    public void Update()
    {
        if (_selected)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            towerPreview.transform.position = mousePos;

            towerPreview.SetActive(true);

            if (Input.GetMouseButton(0))
            {
                if (gameplay.GetMoney() >= 30)
                {
                    gameplay.SpendMoney(30);
                    towerController.PlaceTower();
                }
                _selected = false;
            }
        }
        else
        {
            towerPreview.SetActive(false);
        }
    }

}
