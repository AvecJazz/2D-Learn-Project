using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Health))]
public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject hpBarPanelPrefab;
    private int displayHP;
    private Health health;
    private GameObject hpBarPanel;
    private Text hpBarText;

    private void Awake()
    {
        hpBarPanel = Instantiate(hpBarPanelPrefab);
        hpBarPanel.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        hpBarText = hpBarPanel.transform.Find("HpBarText").GetComponent<Text>();
        health = GetComponent<Health>();
    }

    void Start()
    {
        RefreshHpBar();
    }


    public void RefreshHpBar() 
    {
        displayHP = health.health;
        hpBarText.text = $": {displayHP}";
    }
}
