using System;
using PathCreation;
using UnityEngine;

public class CompanionController : MonoBehaviour
{
    [SerializeField] private PathCreator pathCreator;


    [SerializeField] private float moveSpeed;

    private float distanceTravelled;

    private float inputX;

    [SerializeField] private Transform companionPathFollowerTransform;


    [SerializeField] private float idleMoveSpeed;
    [SerializeField] private float idleMoveOffset;
    [SerializeField] private Transform companionTransform;


    private void Awake()
    {
    }


    private void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");


        distanceTravelled += moveSpeed * inputX * Time.deltaTime;
        distanceTravelled = Mathf.Clamp(distanceTravelled, 0, pathCreator.path.length);

        companionPathFollowerTransform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);


        companionTransform.localPosition = new Vector2(Mathf.Sin(Time.time*idleMoveSpeed)*idleMoveOffset, Mathf.Sin(Time.time*idleMoveSpeed)*idleMoveOffset);
    }
}