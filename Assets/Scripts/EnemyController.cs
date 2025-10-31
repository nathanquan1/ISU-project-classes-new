using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

//
//using System.Numerics; Delete if unity automatically adds it back
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    //base class

    private float _x;
    private float _y;
    private float _speed = 0.5f; //0.5
    private string _direction = "N";
    private Animator animator;
    // use north, south, North east, etc so we can abreviate it
    public GameObject card;

    void Start()
    {
        this._x = transform.position.x; //X AND Y NEEDS TO BE FLOATS ***
        this._y = transform.position.y;
        animator = GetComponent<Animator>();
        ChangeDirection("E");
    }

    void Update()
    {
        //directions
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


        //PATH  
        if (this._x >= -4.1f && this._x <= -4f) //Its a range bc if it checks for an exact value they can pass it
        {
            ChangeDirection("S");
        }
        if (this._y <= -3 && this._y >= -3.2)
        {
            ChangeDirection("E");
        }
        if (this._x >= 0.6f && this._x < 0.7)
        {
            ChangeDirection("N");
        }
        if (this._y >= 1.1 && this._y <= 1.2)
        {
            ChangeDirection("E");
        }
        if (this._x >= 4 && this._x <= 4.1f)
        {
            ChangeDirection("S");
        }
        if (this._y <= 0 && this._y >= -0.1 && this._x >= 4)
        {
            ChangeDirection("E");
        }
        //end of path:
        if (this._x >= 9)
        {
            Destroy(this.gameObject);
        }
        
    }
    public void SpawnCharacter()
    {
        this._x = 0;
        this._y = 540;
        Vector2 spawnPoint = Camera.main.ScreenToWorldPoint(new Vector2(this._x, this._y));
        GameObject newCard = Instantiate(card, spawnPoint, Quaternion.identity); //Need this to move the card
    }
    public void ChangeDirection(string direction)
    {
        this._direction = direction;
        if (direction == "N")
        {
            animator.Play("walk_forward"); //Play specific animation file
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
