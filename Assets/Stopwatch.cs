using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    public bool stopWatchActive = true;
    private float _currentTime;
    public int startMins;
    public TextMeshProUGUI currentTimeText;
    
    void Start()
    {
        _currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.gameOver) _currentTime += Time.deltaTime;

        TimeSpan time = TimeSpan.FromSeconds(_currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:fff");

    }
}
