using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject player1prefab;
    [SerializeField] GameObject player2prefab;

    void Start()
    {
        if(GameManager.Instance.GetCurrentCar == 0)
        {
            GameObject bullet = Instantiate(player1prefab, transform.position, transform.rotation);
        }
        else if (GameManager.Instance.GetCurrentCar == 1)
        {
            GameObject bullet = Instantiate(player2prefab, transform.position, transform.rotation);
        }
    }
}
