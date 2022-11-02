using System.Collections;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int lives = 1;
    private Collider2D _collider;
    public bool _isDead = false;
    private float _pushForce = 15f;
    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject && !Hero.Instance._invincible)
        {
            Hero.Instance.GetDamage();
            Hero.Instance.GetForced(_pushForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetForced(_pushForce);
            lives -= 1;
            if (lives <= 0) Death(); 
        }
    }

    public void Death()
    {
        _isDead = true;

        Vector2 deathDir = transform.position;
        deathDir.y += 10f;

        Destroy(_collider);
        transform.position = Vector2.Lerp(transform.position, deathDir, Time.deltaTime);

        Destroy(gameObject, 3f);
;    }








}
