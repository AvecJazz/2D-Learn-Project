using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{

    public static Player sharedInstance;

    private Health health;

    private void Awake()
    {
        sharedInstance = this;
        health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        health.OnDeath += Death;
    }

    private void OnDisable()
    {
        health.OnDeath -= Death;
    }


    public void Death() 
    {
        Destroy(gameObject);
    }
}
