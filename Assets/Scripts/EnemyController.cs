using System;
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
    
    protected float _x; //Use protected so the other class can use it properly
    protected float _y;
    protected float _z; //layers of enemies
    protected string _direction = "E";// use north, south, North east, etc so we can abreviate it
    private Animator animator;
    public GameObject card;
    public Gameplay gameplay;
    //Stats:
    protected float _speed; //0.5
    protected int _damage;
    protected int _health;
    protected bool spawned = false;
    static int EnemyCount; //Will use to keep track of enemy #

    protected virtual void Start()
    {
        Debug.Log($"Base Start, DMG:{this._damage}");
        this._x = transform.position.x; //X AND Y NEEDS TO BE FLOATS ***
        this._y = transform.position.y;
        animator = GetComponent<Animator>();
        //IMPORTANT: (Basically the only way for the enemies to access the gameplay script)
        if (gameplay == null) {
            gameplay = FindObjectOfType<Gameplay>();//find script
            //Debug.Log(gameplay);
        }
        
        Debug.Log($"Created enemy with speed: {_speed}, Direction: {_direction}, Spawned?:{spawned}");

    }

    void Update()
    {
        //directions
        if (this._direction == "N")
        {
            this._y += this._speed * Time.deltaTime;
            this._z += this._speed * Time.deltaTime * 0.001f;
        }
        else if (this._direction == "E")
        {
            this._x += this._speed * Time.deltaTime;
            this._z = 0;
        }
        else if (this._direction == "S")
        {
            this._y -= this._speed * Time.deltaTime;
            this._z -= this._speed * Time.deltaTime * 0.001f;
        }
        else if (this._direction == "W")
        {
            this._x -= this._speed * Time.deltaTime;
            this._z = 0;
        }
        if (spawned)
        {
            transform.position = new Vector3(this._x, this._y,this._z);
        }
        
        //PATH  
        if (this._x >= -4.1f && this._x <= -4f) //Checks if it is inbetween the right points to turn directions
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
        // NEED SOME WAY TO CHECK IF PREFAB OR NOT / OR I HAVE TO MAKE NEW CRIPT FOR ENEMY SPAWNING
        if (this._x >= 9.2f&&spawned)
        {
            //Deal damage (damage)
            
            Debug.Log($"Speed:{this._speed},X:{this._x},AN ENEMY HAS DEALT {this._damage} DMG");
            gameplay.TakeDamage(this._damage);
            Destroy(this.gameObject);
        }
        if (this._health <= 0&&spawned)
        {
            Destroy(this.gameObject);
        }//Make sure to not let this be targeted if !spawned
    }

    protected virtual void SetStats()
    {
        //Debug.Log("");
        _speed = 0;
        _damage = 0;
        _health = 999;
        this.spawned = false;
    }

    public virtual void SpawnEnemy()
    {

        EnemyCount += 1;
        this._x = 0;
        this._y = 540;
        Vector2 spawnPoint = Camera.main.ScreenToWorldPoint(new Vector2(this._x, this._y));
        GameObject newCard = Instantiate(card, spawnPoint, Quaternion.identity); //Need this to move the card
        Debug.Log("SpawnEnemy();");
        this.spawned = true;
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
        else
        {
            return;
        }
    }
    public void ChangeStats(float speed, int health, int damage)
    {
        this._speed = speed;
        this._health = health;
        this._damage = damage;
    }
}