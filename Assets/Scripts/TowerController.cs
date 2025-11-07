using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject tower;

    protected float damage;
    public static int TowersPlaced;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlaceTower(float x, float y)
    {
        Debug.Log($"{x},{y}");
        //need prefab, also this will be inherited from probably
        TowersPlaced += 1;
        GameObject newTower = Instantiate(tower, new Vector2(x,y), Quaternion.identity); 
    }
}
