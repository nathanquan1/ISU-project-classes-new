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

            
        }
        else
        {
            towerPreview.SetActive(false);
        }
    }

}
