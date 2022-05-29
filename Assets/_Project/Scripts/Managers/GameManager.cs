using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool gameOver;
    public HealthComponent playerHealth;

    public Action OnGameOver;

    public GameObject canvas;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }

        instance = this;
    }

    private void OnEnable() => OnGameOver += GameOver;

    private void OnDisable() => OnGameOver -= GameOver;


    public void GameOver()
    {
        gameOver = true;
        canvas.SetActive(true);
        Time.timeScale = 0.01f;
        Debug.Log("Oyun bitti amına koduklarım");
    }
}