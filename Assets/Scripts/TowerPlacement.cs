using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public Gameplay gameplay;
    public GameObject towerPreview; 
    public GameObject pathway;
    public TowerController towerController;
    public CannonTowerController cannonTowerController;
    public MinigunTowerController minigunTowerController;
    public MissileTowerController missileTowerController;

    //public bool TouchingPath;
    protected bool _selected = false;
    protected int Price;

    //fix the issue where it can only select cannon later
    protected virtual void togglePlacing()
    {
        _selected = !_selected;
        Debug.Log($"Tower button clicked. selected:{_selected}");
    }
    protected virtual void Start()
    {
        towerPreview.SetActive(false);
        pathway.SetActive(false);
    }
    protected virtual void Update()
    {
        towerPreview.SetActive(_selected); //will only show if selected
        pathway.SetActive(_selected);
        if (_selected)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            towerPreview.transform.position = mousePos;
            if (Input.GetMouseButton(0)) //click
            {

                if (gameplay.GetMoney() >= Price)
                {
                    Debug.Log($"Placed tower for {Price}");
                    gameplay.SpendMoney(Price);
                    Place();
                }
                _selected = false;
            }
        }
        else
        {
            towerPreview.SetActive(false);
        }
    }
    protected virtual void Place()//Made this so the different buttons can inherit it for different prices+sprites
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        towerController.PlaceTower(mousePos.x, mousePos.y); //default to cannon
    }
}
