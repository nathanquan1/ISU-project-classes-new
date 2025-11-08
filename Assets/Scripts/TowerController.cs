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

 
    [SerializeField] protected float range = 3.5f;//tower range
    [SerializeField] protected float fireRate = 1.0f;//Number of launches per second
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected float bulletSpeed = 6f;//Bullet speed

    private float _cooldownTimer = 0f;

    void Start()
    {
        // Automatic configuration based on tower instance name
        AutoSetup();

        if (fireRate > 0f) cooldown = 1f / fireRate;
        else cooldown = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        _cooldownTimer += Time.deltaTime;

        //if placed && enemy touching range && timer>0 {
        //attack + timer=0

        // Automatic enemy detection + cooldown assessment + firing
        if (_cooldownTimer >= cooldown && bulletPrefab != null)
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
        // Execute SetStats on the "new instance"
        var ctrl = newTower.GetComponent<TowerController>();
        if (ctrl != null)
        {
            // Call its own SetStats
            ctrl.SendMessage("SetStats", SendMessageOptions.DontRequireReceiver);

            // Perform automatic configuration on new instances as well, ensuring they have the correct bullets and parameters.
            ctrl.SendMessage("AutoSetup", SendMessageOptions.DontRequireReceiver);
            // Cooldown refreshed based on fireRate
            if (ctrl.fireRate > 0f) ctrl.cooldown = 1f / ctrl.fireRate;
        }
    }

    protected virtual void SetStats()
    {
        damage = 0;
    }

    // Select the target based on its "first" priority.
    protected EnemyController SelectFrontMostTargetInRange()
    {
        EnemyController[] all = FindObjectsOfType<EnemyController>();
        if (all == null || all.Length == 0) return null;

        float goalX = 9.2f;
        Vector3 myPos = transform.position;

        EnemyController best = null;
        float bestScore = float.MaxValue; // The closer to the finish line, the better (lower score).

        foreach (var e in all)
        {
            if (e == null) continue;
            Vector3 ep = e.transform.position;
            // Range judgment
            if (Vector3.Distance(myPos, ep) > range) continue;

            float score = Mathf.Abs(goalX - ep.x); // Simplified metric: the difference from the endpoint x
            if (score < bestScore)
            {
                bestScore = score;
                best = e;
            }
        }
        return best;
    }

    // Instantiate bullets
    protected void FireAt(EnemyController target)
    {
        if (target == null) return;
        if (bulletPrefab == null) return;

        // Bullet spawn point: Tower center
        Vector3 spawnPos = transform.position;
        GameObject go = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);

        // Straight-line bullets: Lock onto the target's position at the moment of firing.
        Vector3 lockPos = target.transform.position;

        BulletController bc = go.GetComponent<BulletController>();
        if (bc == null) bc = go.AddComponent<BulletController>(); // To prevent scripts from being installed
        bc.Init(lockPos, damage, bulletSpeed, target);
    }


    void AutoSetup()
    {
        string n = gameObject.name.ToLower();

        // Automatic bullet matching Prefab
        if (bulletPrefab == null)
        {
            if (n.Contains("cannon")) bulletPrefab = Resources.Load<GameObject>("Bullet_Cannon");
            else if (n.Contains("mg")) bulletPrefab = Resources.Load<GameObject>("Bullet_MG");
            else if (n.Contains("missile")) bulletPrefab = Resources.Load<GameObject>("Missile");
        }

        // Automatically set rate of fire/range/bullet velocity
        if (n.Contains("cannon"))
        {
            if (fireRate   <= 0f) fireRate = 0.75f;
            if (range      <= 0f) range = 3.5f;
            if (bulletSpeed<= 0f) bulletSpeed = 6f;
        }
        else if (n.Contains("mg"))
        {
            if (fireRate   <= 0f) fireRate = 4.0f;
            if (range      <= 0f) range = 3.0f;
            if (bulletSpeed<= 0f) bulletSpeed = 8f;
        }
        else if (n.Contains("missile"))
        {
            if (fireRate   <= 0f) fireRate = 1.0f;
            if (range      <= 0f) range = 4.0f;
            if (bulletSpeed<= 0f) bulletSpeed = 7f;
        }
    }
}
