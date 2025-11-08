using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject tower;
    protected float timer;
    protected float damage;
    public static int TowersPlaced;
    protected float _x;
    protected float _y;

 
    protected float range = 3.5f;//tower range
    protected float fireRate = 1.0f;//Number of launches per second
    public GameObject bulletPrefab;
    protected float bulletSpeed = 6f;//Bullet speed

    protected float _cooldownTimer = 0f;

    void Start()
    {
        SetStats();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        _cooldownTimer += Time.deltaTime;

        //if placed && enemy touching range && timer>0 {
        //attack + timer=0

        // Automatic enemy detection + cooldown assessment + firing
        if (_cooldownTimer >= fireRate && bulletPrefab != null)
        {
            EnemyController target = SelectFrontMostTargetInRange();
            if (target != null)
            {
                FireAt(target);
                _cooldownTimer = 0f;
            }
        }
    }

    public void PlaceTower(float x, float y)
    {
        Debug.Log($"{x},{y}");
        TowersPlaced += 1;
        GameObject newTower = Instantiate(tower, new Vector2(x, y), Quaternion.identity);
        this._x = x;
        this._y = y;
        SetStats();
        
    }

    protected virtual void SetStats()
    {
        damage = 1; //defaults to cannon in case of glitch
        fireRate = 0.75f;
        range = 3.5f;
        bulletSpeed = 6f;
    }

    //Selects target closest to the end
    protected EnemyController SelectFrontMostTargetInRange()
    {
        EnemyController[] all = FindObjectsOfType<EnemyController>(); //list of all enemies
        if (all == null || all.Length == 0) return null;

        float goalX = 9.2f;//End of the path 
        Vector3 myPos = transform.position;

        EnemyController best = null;
        float bestScore = float.MaxValue;

        foreach (var e in all) //checks every currently spawned enemy
        {
            if (e == null) continue;
            Vector3 ep = e.transform.position; //ep= enemyposition
            // Range judgment
            if (Vector3.Distance(myPos, ep) < range) continue;

            float score = Mathf.Abs(goalX - ep.x); //end point x value - enemyposition x value
            if (score < bestScore)
            {
                bestScore = score;
                best = e; //best enemy to attack
            }
        }
        Debug.Log(myPos);
        Debug.Log($"shooting at {best} from pos:{myPos.x},{myPos.y}");
        return best;
    }

    // Instantiate bullets
    protected void FireAt(EnemyController target)
    {
        if (target == null) return;
        if (bulletPrefab == null) return;

        //Bullet spawn point
        Vector3 towerPos = transform.position;//created from placed tower
        GameObject go = Instantiate(bulletPrefab, towerPos, Quaternion.identity);

        // Straight-line bullets: Lock onto the target's position at the moment of firing.
        Vector3 lockPos = target.transform.position;

        BulletController bc = go.GetComponent<BulletController>();
        if (bc == null) bc = go.AddComponent<BulletController>(); // To prevent scripts from being installed
        bc.Init(lockPos, damage, bulletSpeed, target);

        //target.ApplyDamage(damage);
    }
}
