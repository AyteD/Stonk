using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int damage = 1;

    private void OnTriggerEntre2D(Collider2D collision)
    {
        if(collision.CompareTag("Mouvement"))  
        {
            Debug.Log("Touché"); ;
            Mouvement.instance.TakeDamage(damage);
        }
    }
}
