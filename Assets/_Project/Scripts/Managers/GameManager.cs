using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Action OnGameOver;
    public HealthComponent player;


    [SerializeField] private GameObject gameOverCanvas;
    

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }

        instance = this;
    }


    private void OnEnable()
    {
        OnGameOver += GameOver;
    }
    
    private void OnDisable()
    {
        OnGameOver -= GameOver;
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
}