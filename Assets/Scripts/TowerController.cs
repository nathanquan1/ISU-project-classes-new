using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject tower;
    protected float timer;
    protected float damage;
    protected float cooldown;
    public static int TowersPlaced;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //if placed && enemy touching range && timer>0 {
        //attack + timer=0
    }
    public void PlaceTower(float x, float y)
    {
        Debug.Log($"{x},{y}");
        TowersPlaced += 1;
        GameObject newTower = Instantiate(tower, new Vector2(x, y), Quaternion.identity);
        SetStats();

    }
    protected virtual void SetStats()
    {
        damage = 0;
    }
}
