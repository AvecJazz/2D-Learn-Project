using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{

    public int health;

    public bool alive = true;

    private HPBar hpBar;

    public event Action OnDeath;


    private void Awake()
    {
        hpBar = GetComponent<HPBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            alive = false;
            OnDeath?.Invoke();
        }
    }

    public void TakeDamage(int damage) 
    {
        health -= damage;

        if (hpBar != null) 
        {
            hpBar.RefreshHpBar();
        }
    }

}
