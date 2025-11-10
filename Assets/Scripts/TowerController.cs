 using System.Collections;
using System.Collections.Generic;

//using System.Numerics;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject tower;
<<<<<<< HEAD
    protected float timer;
=======
>>>>>>> a46e9ae2fd6e64515ecab7a84d17b538924c94c2
    protected float damage;
    public int speed;
    public static int TowersPlaced;
    protected float _x;
    protected float _y;
    protected float _angle;
 
    protected float range;//tower range
    protected float fireRate;//Number of launches per second
    public GameObject bulletPrefab;
    protected float bulletSpeed;//Bullet speed

    protected float _cooldownTimer;
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
        if (_cooldownTimer >= fireRate&& bulletPrefab!=null)
        {
            EnemyController target = SelectFrontMostTargetInRange();

            if (target != null)
            {
                //fire at enemy
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
<<<<<<< HEAD
        damage = 1; //defaults to cannon in case of glitch
        fireRate = 0.75f;
        range = 3.5f;
        bulletSpeed = 6f;
    }

    //Selects target closest to the end
    protected EnemyController SelectFrontMostTargetInRange()
    {
        EnemyController[] all = FindObjectsOfType<EnemyController>(); //list of all enemies
        if (all == null || all.Length == 0)
        {
            return null;
        }
        Vector3 myPos = transform.position;

        EnemyController best = null;
        float furthestDistance = 0;

        foreach (var e in all) //checks every currently spawned enemy
        {
            if (e == null) continue;//skip
            Vector3 ep = e.transform.position; //ep= enemyposition
            //Range judgment
            if (Vector3.Distance(myPos, ep) > range) continue; //if out of range skip to next

            float distance = e.getDistance(); //distance
            if (distance > furthestDistance)
            {
                furthestDistance = distance;
                best = e; //best enemy to attack (whoever has highest distance)
            }
        }
        Debug.Log(myPos);
        Debug.Log($"shooting at {best} from pos:{myPos.x},{myPos.y}");
        return best;
    }

    //Instantiate bullets
    protected void FireAt(EnemyController target)
    {
        if (target == null) return;

        //Bullet spawn point
        Vector3 towerPos = transform.position;//created from placed tower
        GameObject go = Instantiate(bulletPrefab, towerPos, Quaternion.identity);

        //Lock onto the target's current position when bullet fired
        Vector3 lockPos = target.transform.position;
        
        //rotate when firing
        Vector3 direction = target.transform.position - transform.position; //difference in coordinates
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //Finds angle towards target
        Quaternion rotate = Quaternion.Euler(0, 0, angle+270); //rotate an extra 270
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotate, 360); //max 360


        BulletController bc = go.GetComponent<BulletController>();
        if (bc == null) bc = go.AddComponent<BulletController>(); // To prevent scripts from being installed
        bc.Init(lockPos, damage, bulletSpeed, target,angle);
        //target.ApplyDamage(damage);


        
=======
        damage = 4;
    }
    public void HitEnemy(EnemyController enemy)
    {
        enemy._health -= damage;

>>>>>>> a46e9ae2fd6e64515ecab7a84d17b538924c94c2
    }
}
