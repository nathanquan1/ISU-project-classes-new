using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class CardMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = new Vector2(0, 1);//up 1 pixel
        transform.Translate(move.x* Time.deltaTime, move.y *Time.deltaTime,0);//xyz
    }
    public void SpawnCharacter()
    {
        //x,y,z
        transform.position = new Vector2(960,0);
    }
}
