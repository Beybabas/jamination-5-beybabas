using System;
using PathCreation;
using UnityEngine;

public class CompanionController : MonoBehaviour
{
    [SerializeField] private PathCreator pathCreator;


    [SerializeField] private float moveSpeed;

    private float distanceTravelled;

    private float inputX;

    [SerializeField] private Transform companionTransform;


    private void Awake()
    {
    }


    private void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");


        distanceTravelled += moveSpeed * inputX * Time.deltaTime;
        distanceTravelled = Mathf.Clamp(distanceTravelled, 0, pathCreator.path.length);

        companionTransform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
    }
}