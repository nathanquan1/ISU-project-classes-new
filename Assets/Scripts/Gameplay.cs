using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    // Start is called before the first frame update
    public bool GameRunning = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameRunning)
        {
            //
        }
    }
    public void StartGame()
    {
        //i think it needs to be static for it to be used in other file
        GameRunning = true;

    }
    public void EndGame()
    {
        GameRunning = false;
    }
}
