using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public Gameplay gameplay;
    private bool _selected = false;
    public void buttonSelected()
    {
        _selected = !_selected;
        
    }

}
