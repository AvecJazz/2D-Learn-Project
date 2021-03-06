using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Health))]
public class HPBar : MonoBehaviour
{
    [SerializeField] Text hpBarTextPrefab;
    private int displayHP;
    private Health health;

    private Text hpBarText;

    private void Awake()
    {
        hpBarText = Instantiate(hpBarTextPrefab);
        hpBarText.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        health = GetComponent<Health>();
    }

    void Start()
    {
        RefreshHpBar();
    }


    public void RefreshHpBar() 
    {
        displayHP = health.health;
        hpBarText.text = $"HP: {displayHP}";
    }
}
