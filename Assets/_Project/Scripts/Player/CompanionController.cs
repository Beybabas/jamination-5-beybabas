using System;
using PathCreation;
using Unity.Mathematics;
using UnityEngine;

public class CompanionController : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    [SerializeField] private Transform _companionTransform;

    [SerializeField] private int clockWise;
    [SerializeField] private bool isClockWise;


    private void Awake()
    {
        
    }

    private void Start()
    {
        EventManager.ClockWiseEvent();
    }


    private void OnEnable()
    {
        EventManager.OnclockWise += ClockWise;
        EventManager.OncounterClockWise += CounterClockWise;

    }

    private void OnDisable()
    {
        EventManager.OnclockWise -= ClockWise;
        EventManager.OncounterClockWise -= CounterClockWise;
    }

    private void Update()
    {
        _companionTransform.RotateAround(transform.position, Vector3.forward, _rotateSpeed * Mathf.Sin(Time.deltaTime) * 10f * clockWise);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (isClockWise)
            {
                EventManager.CounterClockWiseEvent();
            }
            else
            {
                EventManager.ClockWiseEvent();
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