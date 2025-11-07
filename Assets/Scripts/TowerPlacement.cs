using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public Gameplay gameplay;
    public GameObject towerPreview;
    public GameObject pathway;
    public TowerController towerController;
    private bool _selected = false;
    public void togglePlacing()
    {
        _selected = !_selected;
    }
    public void Start()
    {
        towerPreview.SetActive(false);
        pathway.SetActive(false);
    }
    public void Update()
    {
        towerPreview.SetActive(_selected); //will only show if selected
        pathway.SetActive(_selected);

        if (_selected)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            towerPreview.transform.position = mousePos;

            if (Input.GetMouseButton(0)) //click
            {
                if (gameplay.GetMoney() >= 30)
                {
                    gameplay.SpendMoney(30);
                    towerController.PlaceTower(mousePos.x,mousePos.y);
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
