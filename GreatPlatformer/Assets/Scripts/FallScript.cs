using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallScript : MonoBehaviour
{
    private float _pushForce = 30f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            if (!Hero.Instance._invincible) Hero.Instance.GetDamage();
            Hero.Instance.GetForced(_pushForce);
        }
        else if (collision.tag == "Entity") Destroy(collision.gameObject, 2f);
    }
}
