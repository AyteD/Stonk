using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class SpikeDamage : MonoBehaviour
{

    private Player _player;
    private Transform _playerSpaw;


    private void Awake()
    {
        _playerSpaw = GameObject.FindGameObjectWithTag("PlayerSpawn").transform; // on le recupère 1 fois au début, pour ne pas le faire à chaque entré en deathzone

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            _player = Player.instance;

            _player.TakeDamage(1);
            // set postion player sur checkpoint

            _player.transform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            _player.transform.position = _playerSpaw.position;
        }
    }










}
