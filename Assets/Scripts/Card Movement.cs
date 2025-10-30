using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

//
//using System.Numerics; Delete if unity automatically adds it back
using UnityEngine;
using UnityEngine.UIElements;

public class CardMovement : MonoBehaviour
{
    //base class
    private float _x;
    private float _y;
    private float _speed = 0.5f;
    private string _direction = "N";
    private Animator animator;
    // use north, south, North east, etc so we can abreviate it
    public GameObject card;

    void Start()
    {
        this._x = transform.position.x; //X AND Y NEEDS TO BE FLOATS ***
        this._y = transform.position.y;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (this._direction == "N")
        {
            this._y += this._speed * Time.deltaTime;
        }
        else if (this._direction == "E")
        {
            this._x += this._speed * Time.deltaTime;
        }
        else if (this._direction == "S")
        {
            this._y -= this._speed * Time.deltaTime;
        }
        else if (this._direction == "W")
        {
            this._x -= this._speed * Time.deltaTime;
        }
        

        transform.position = new Vector2(this._x, this._y);
    }
    public void SpawnCharacter()
    {
        //SPAWN BOTTOM CENTER : 960,0 for now
        this._x = 960;
        this._y = 0;
        
        Vector2 spawnPoint = Camera.main.ScreenToWorldPoint(new Vector2(this._x, this._y));
        GameObject newCard = Instantiate(card, spawnPoint, Quaternion.identity); //Need this to move the card
    }
    public void ChangeDirection(string direction)
    {
        this._direction = direction;
        if (direction == "N")
        {
            animator.Play("walk_up"); //Play specific animation file
        }
        else if (direction == "E")
        {
            animator.Play("walk_right");
        }
        else if (direction == "S")
        {
            animator.Play("walk_down");
        }
        else if (direction == "W")
        {
            animator.Play("walk_left");
        }
    }
}
