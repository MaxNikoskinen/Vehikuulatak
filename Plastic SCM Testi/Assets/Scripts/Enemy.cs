using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for handling enemy behaviour

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject effect;
    public GameObject corpse;


    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Instantiate(corpse, transform.position, Quaternion.identity);
            Instantiate(effect, transform.position, Quaternion.identity);
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
