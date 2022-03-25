using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for handling enemy behaviour

public class Enemy : MonoBehaviour
{
    public int health = 100;

    
    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {

            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
