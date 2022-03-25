using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script that handles the player, health and stuff like that

public class Player : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int health;

    private void Start()
    {
        UIManager.Instance.UpdateHealthText(maxHealth);
        health = maxHealth;
        GameManager.Instance.player = this.gameObject;
    }

    //Method for taking damage
    public void TakeDamage(int amount)
    {
        health -= amount;
        UIManager.Instance.UpdateHealthText(health);
        if (health <= 0)
        {
            UIManager.Instance.UpdateHealthText(0);
            GameManager.Instance.player = null; //Put to gamemanager that the player doesn't exist to prevent nre
            Die();
        }
    }

    //Method for dying
    public void Die()
    {
    
        Destroy(gameObject);
    }
}
