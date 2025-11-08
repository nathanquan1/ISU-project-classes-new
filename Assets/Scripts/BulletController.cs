using UnityEngine;

// Universal Bullet (Straight Line): Locates a target at spawn and flies towards it; upon reaching a threshold, it hits and is destroyed.
public class BulletController : MonoBehaviour
{
    private Vector3 _lockPos;
    private float _damage;
    private float _speed;
    private EnemyController _targetRef; // This is only used to determine if the target still exists (no continuous tracking is performed).
    private float _life = 3f; // Insurance: Destroyed if it doesn't hit within 3 seconds.
    private float _hitDistance = 0.15f;

    public void Init(Vector3 lockPos, float damage, float speed, EnemyController targetRef)
    {
        _lockPos = lockPos;
        _damage = damage;
        _speed = speed;
        _targetRef = targetRef;
    }

    void Update()
    {
        // Move in a straight line towards the lock point
        transform.position = Vector3.MoveTowards(transform.position, _lockPos, _speed * Time.deltaTime);

        // Hit detection (distance threshold)
        if (Vector3.Distance(transform.position, _lockPos) <= _hitDistance)
        {
            if (_targetRef != null)
            {
                _targetRef.ApplyDamage(_damage);
            }
            Destroy(gameObject);
            return;
        }

        // Insurance life
        _life -= Time.deltaTime;
        if (_life <= 0f) Destroy(gameObject);
    }
}
