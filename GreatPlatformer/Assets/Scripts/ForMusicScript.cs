using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForMusicScript : MonoBehaviour
{
    [SerializeField] private AudioClip[] _currentMusic;
    [SerializeField] private AudioSource _music;

 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            _music.Stop();
            _music.clip = _currentMusic[0];
            _music.Play();
        }
    }

}
