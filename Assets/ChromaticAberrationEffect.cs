using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ChromaticAberrationEffect : MonoBehaviour
{
    public static ChromaticAberrationEffect Instance;

    private Volume volume;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        
        volume = GetComponent<Volume>();
    }

    
    void Update()
    {
        if (volume.weight > 0)
        {
            float decreaseSpeed = 2f;
            volume.weight -= Time.deltaTime * decreaseSpeed;
        }
    }

    public void SetWeight(float weight)
    {
        volume.weight = weight;
    }
}
