using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int damage = 1;

    private void OnTriggerEntre2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))  
        {
            Debug.Log("Touché"); //ecrie touher si le player touche l'énemei (c'est un test)
            Player.instance.TakeDamage(damage); // inflige un de dégat 
        }
    }
}
