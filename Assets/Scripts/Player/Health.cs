using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{

    public int maxHealth;
    public bool alive = true;
    [HideInInspector]
    public int health;  

    private HPBar hpBar;

    public event Action OnDeath;


    private void Awake()
    {
        hpBar = GetComponent<HPBar>();
    }

    private void Start()
    {
        health = maxHealth;
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

    public bool RestoreHealth(int addToHealth) 
    {
        if (health < maxHealth) 
        {
            health += addToHealth;

            if (hpBar != null)
            {
                hpBar.RefreshHpBar();
            }

            return true;
        }
        return false;
    }

}
