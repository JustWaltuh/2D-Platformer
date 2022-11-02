using UnityEngine;

public class WalkingMonster : Entity
{

    [SerializeField] private Vector3 _dir;
    private SpriteRenderer _sprite;

    private void Start()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _dir = transform.right;
    }

    private void FixedUpdate()
    {
        if (((Entity)this)._isDead == false)
        {
            Move();
        }
    }

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + transform.right * _dir.x * 0.05f, 0.35f);

        if (colliders.Length > 1)  _dir *= -1f;
        _sprite.flipX = _dir.x > 0.0f;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + _dir, Time.deltaTime);
    }

   /* private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.up * 0.1f + transform.right * _dir.x * 0.05f, 0.35f);
        //transform.position + transform.up * 0.1f + transform.right * _dir.x * 0.6f, 0.1f
    }*/
}
