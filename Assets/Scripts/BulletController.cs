using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Vector3 _lockPos;
    private float _damage;
    private float _speed;
    private float _angle;
    private EnemyController _targetRef; // This is only used to determine if the target still exists (no continuous tracking is performed).
    private float _life = 3f; // Insurance: Destroyed if it doesn't hit within 3 seconds.
    private float _hitDistance = 0.15f;

    public void Init(Vector3 lockPos, float damage, float speed, EnemyController targetRef, float angle)
    {
        _lockPos = lockPos;
        _damage = damage;
        _speed = speed;
        _targetRef = targetRef;

        //rotate bullet 
        Quaternion rotate = Quaternion.Euler(0, 0, angle+270); //rotate an extra 270
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotate, 360); //max 360
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
