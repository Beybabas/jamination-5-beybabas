using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveSpawner : MonoBehaviour
{
    [Title("Waves")]
    public Wave[] waves;
    
    [Title("Spawn Points")]
    public Transform[] spawnPoints;
    
    [Title("Time Between Waves")]
    public float timeBetweenWaves;

    private Wave _currentWave;

    private int _currentWaveIndex;
    private void Start()
    {
        StartCoroutine(StartWave());
    }
    

    public IEnumerator StartWave()
    {
        while (true)
        {
            _currentWave = waves[_currentWaveIndex % waves.Length];

            if (GameManager.instance.playerHealth.CurrentHealth <= 0) yield break;
            
            for (int i = 0; i < _currentWave.count; i++)
            {
                var randomPoint = Random.Range(0, spawnPoints.Length);
                var randomEnemy = _currentWave.enemies[Random.Range(0, _currentWave.enemies.Length)];
                Instantiate(randomEnemy, spawnPoints[randomPoint].position, Quaternion.identity);
                yield return new WaitForSeconds(_currentWave.timeBetweenSpawns);
            }

            yield return new WaitForSeconds(timeBetweenWaves);
            _currentWaveIndex++;
        }
    }
    
}

[Serializable]
public class Wave
{
    public GameObject[] enemies;
    public int count;
    public float timeBetweenSpawns;
}