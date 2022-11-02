using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 pos;
    private Vector3 offset; 

    private void Awake()
    {
        if (!player)
            player = FindObjectOfType<Hero>().transform;

        offset.y = 2f;
    }

    private void Update()
    {
        pos = player.position;
        pos.z = -10f;


        transform.position = Vector3.Lerp(transform.position, pos + offset, Time.deltaTime * 3f);
    }
}
