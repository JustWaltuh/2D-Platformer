using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingTile : MonoBehaviour
{
    private SpriteRenderer _sprite;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject) StartCoroutine(DestroyTile());
    }

    public IEnumerator DestroyTile()
    {
        for(float f = 1f; f >= 0; f -= 0.05f)
        {
            _sprite.color = new Color(1, f, f, 1);
            yield return new WaitForSeconds(0.05f);
        }
        DestroyImmediate(gameObject);
    }
}
