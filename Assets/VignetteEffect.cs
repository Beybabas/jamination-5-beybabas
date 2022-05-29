using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class VignetteEffect : MonoBehaviour
{
    [SerializeField] private HealthComponent health;

    private Volume volume;

    private void Awake()
    {
        volume = GetComponent<Volume>();
    }

    private void OnEnable()
    {
        health.OnHealthDecrease += SetVignette;
    }
    

    private void SetVignette()
    {
        volume.weight = 1 - health.Ratio;
    }
    private void OnDisable()
    {
        health.OnHealthDecrease -= SetVignette;
    }
}
