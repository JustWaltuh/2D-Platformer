using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantMonster : Entity
{
    [SerializeField] private Vector3 _dir;
    private SpriteRenderer _sprite;
    [SerializeField] private GameObject _door;

    private void Start()
    {
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _dir = transform.right;

        ((Entity)this).lives = 3;
    }

    private void FixedUpdate()
    {
        if (((Entity)this)._isDead == false)
        {
            Move();
        }

        if (((Entity)this).lives <= 0)
            _door.SetActive(false);
    }

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.6f + transform.right * _dir.x * 0.05f, 2f);

        if (colliders.Length > 1) _dir *= -1f;
        _sprite.flipX = _dir.x > 0.0f;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + _dir, Time.deltaTime);
    }
}
