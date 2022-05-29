using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerController player;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }

        instance = this;
    }


    public void GameOver()
    {
        Debug.Log("Oyun bitti amına koduklarım");
    }
}