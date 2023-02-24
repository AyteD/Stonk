using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Transform _playerSpawn;


    private void Awake()
    {
        _playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerSpawn.position = transform.position;
        }
    }
}