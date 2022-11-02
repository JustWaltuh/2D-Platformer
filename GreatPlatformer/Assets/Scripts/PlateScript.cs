using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateScript : MonoBehaviour
{
    [SerializeField] private GameObject _interactionObject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _interactionObject.SetActive(false);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        _interactionObject.SetActive(false);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        StartCoroutine(DisableObject());
    }

    private IEnumerator DisableObject()
    {

        yield return new WaitForSeconds(2.5f);
        _interactionObject.SetActive(true);
    }
}
