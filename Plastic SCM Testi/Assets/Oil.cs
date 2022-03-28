using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : MonoBehaviour
{
    private SpriteRenderer rend;
    public Sprite[] oil;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        int rand = Random.Range(0, oil.Length);
        rend.sprite = oil[rand];
    }

}
