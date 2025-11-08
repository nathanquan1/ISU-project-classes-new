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

 
    [SerializeField] protected float range = 3.5f;               // range
    [SerializeField] protected float fireRate = 1.0f;            // Number of launches per second
    [SerializeField] protected GameObject bulletPrefab;          // Bullet Prefab
    [SerializeField] protected float bulletSpeed = 6f;           // Bullet velocity (world units/second)

    private float _cooldownTimer = 0f;

    void Start()
    {

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
        SetStats();

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
}
