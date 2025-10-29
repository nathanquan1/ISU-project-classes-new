using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

//

//using System.Numerics; Delete if unity automatically adds it back
using UnityEngine;
using UnityEngine.UIElements;

public class CardMovement : MonoBehaviour
{
    private float _x;
    private float _y;
    private int _speed = 1;

    public GameObject card;

    void Start()
    {
        _x = transform.position.x; //X AND Y NEEDS TO BE FLOATS ***
        _y = transform.position.y;
    }

    void Update()
    {
        _y += this._speed * Time.deltaTime; //multiply by time because ifyou dont then fps will effect speed
        transform.position = new Vector2(this._x, this._y);
    }
    public void SpawnCharacter()
    {
        
        //SPAWN BOTTOM CENTER : 960,0
        this._x = 960;
        this._y = 0;
        Vector2 spawnPoint = new Vector2(this._x, this._y);
        GameObject newCard = Instantiate(card, spawnPoint, Quaternion.identity); //Need this to move the card
    }
}
// class might not be needed
public class TungSahur : CardMovement
{
    private int _speed = 2;
}
