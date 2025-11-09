using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    protected RaycastHit2D hit;
    protected bool touchingPath;

    //public bool TouchingPath;
    protected bool _selected = false;
    protected int Price;

    //fix the issue where it can only select cannon later
    public void togglePlacing()
    {
        _selected = !_selected;
    }
    protected virtual void Start()
    {
        towerPreview.SetActive(false);
        pathway.SetActive(false);
        touchingPath = false;
    }
    protected virtual void Update()
    {
        towerPreview.SetActive(_selected); //will only show if selected
        pathway.SetActive(_selected);

        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); //is set to what mouse is touching, vector2.zero means no direction since 2d
        //bool touchingPathComponents = hit.collider.transform.IsChildOf(pathway.transform);
        touchingPath =  hit.collider != null && hit.collider.transform.IsChildOf(pathway.transform); //mouse touching path bool variable 
        Debug.Log($"{touchingPath}");//ischildof checks if it is touching the pathway components since it is broken up into multiple gameobjects

        if (_selected)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            towerPreview.transform.position = mousePos;//moves the preview image to your mouse
            if (Input.GetMouseButton(0) &&!touchingPath) //click
            {

                if (gameplay.GetMoney() >= Price)
                {
                    Debug.Log($"Placed tower for {Price}");
                    gameplay.SpendMoney(Price);
                    Place();
                }
                _selected = false;
            }
            else if (Input.GetKey(KeyCode.X))//x to cancel
            {
                _selected = false;
            }
        }
        else
        {
            towerPreview.SetActive(false);
        }
    }
    public void Place()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//screentoworld converts it into the right x ,y value in the game
        towerController.PlaceTower(mousePos.x, mousePos.y);
    }
}
