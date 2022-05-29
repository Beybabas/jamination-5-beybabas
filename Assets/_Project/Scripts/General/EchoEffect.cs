using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using DG.Tweening;

public class EchoEffect : MonoBehaviour
{
    private float elapsedTime;
    [SerializeField] private float spawnInterval;

    [SerializeField] private float fadeTime;


    public GameObject echo;


    [SerializeField] private PlayerController _playerController;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerController.IsDashing())
            return;


        elapsedTime += Time.deltaTime;

        if (elapsedTime >= spawnInterval)
        {
            var created = Instantiate(echo, transform.position, quaternion.identity);

            created.GetComponent<SpriteRenderer>().DOFade(0, fadeTime).OnComplete(() => Destroy(created));
            elapsedTime = 0;
        }
    }
}