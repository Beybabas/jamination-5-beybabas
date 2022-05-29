using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MainMenuCompanionControlle : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    [SerializeField] private Transform _companionTransform;

    [SerializeField] private int clockWise;
    [SerializeField] private bool isClockWise;


    [SerializeField] private float elapsedTime;

    [SerializeField] private BulletBehaviour bulletBehaviour;


    [SerializeField] private float elapsedFireCounter;


    private void Awake()
    {
        ClockWise();
    }

    private void Start()
    {
    }


    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    private void Update()
    {
        _companionTransform.RotateAround(transform.position, Vector3.forward, _rotateSpeed * Mathf.Sin(Time.deltaTime) * 10f * clockWise);

        elapsedTime += Time.deltaTime;
        elapsedFireCounter += Time.deltaTime;
        if (elapsedFireCounter >= 0.1f)
        {
            elapsedFireCounter = 0;
            var _bullet = Instantiate(bulletBehaviour, _companionTransform.position, quaternion.identity).GetComponent<BulletBehaviour>();

            var shootDir = (_companionTransform.position - transform.position).normalized;

            if (isClockWise)
            {
                _bullet.SelectSingleShot();
            }
            else
            {
                _bullet.SelectBigShot();
            }


            _bullet.AddForce(shootDir);
        }


        if (elapsedTime >= 2)
        {
            elapsedTime = 0;
            if (isClockWise)
            {
                CounterClockWise();
            }
            else
            {
                ClockWise();
            }
        }
    }


    private void ClockWise()
    {
        clockWise = 1;
        isClockWise = true;
    }

    private void CounterClockWise()
    {
        clockWise = -1;
        isClockWise = false;
    }
}