using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject && !Hero.Instance._invincible) 
        {
            Hero.Instance.GetDamage();
            Hero.Instance.GetForced(15f);
        }
    }

}
