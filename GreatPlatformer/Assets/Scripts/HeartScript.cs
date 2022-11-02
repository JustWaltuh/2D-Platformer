using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject && Hero.Instance._health < 5)
        {
            Hero.Instance.GetHealth();
            Destroy(gameObject);
        }
    }
}
