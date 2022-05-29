using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image img;
    
    private HealthComponent health;
    private void Awake()
    {
        health = GetComponent<HealthComponent>();
    }

    private void OnEnable()
    {
        health.OnHealthDecrease += SetRatio;
    }
    
    private void OnDisable()
    {
        health.OnHealthDecrease -= SetRatio;
    }

    private void SetRatio()
    {
        img.fillAmount = health.Ratio;
    }
}
