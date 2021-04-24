using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] public bool isWanderer = false;

    [SerializeField] float maxSpeed = 100;
    [SerializeField] float maxForce = 10;
    [SerializeField] float slowingRadius = 2f;
    [SerializeField] float maxForceIncrease = 1f;
    [SerializeField] float maxForceDecrease = 1f;
    [SerializeField] float maxSpeedIncrease = 200f;
    [SerializeField] float maxSpeedDecrease = 200f;

    public Vector2 targetPosition;
    private Rigidbody2D thisRigidbody;


    public void SetTargetPosition(Vector2 position)
    {
        targetPosition = position;
    }

    private void Awake()
    {
        thisRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        targetPosition = thisRigidbody.position;
    }

    private void FixedUpdate()
    {
        SteerVehicle();
    }



    private void SteerVehicle()
    {
        Vector2 seek = SeekSteer();

        seek *= 0.5f;

        if (!isWanderer)
        {
            thisRigidbody.AddForce(seek, ForceMode2D.Impulse);
        }
        else
        {
            thisRigidbody.AddForce(seek);
        }
    }

    private Vector2 SeekSteer()
    {
        Vector2 desiredVelocity = (Vector2)targetPosition - thisRigidbody.position;
        float distance = desiredVelocity.magnitude;
        Vector2 desiredDirection = desiredVelocity.normalized;

        if (distance < slowingRadius)
        {
            float mappedSpeed = distance * maxSpeed / slowingRadius;
            desiredVelocity = desiredDirection * mappedSpeed * Time.fixedDeltaTime;
        }
        else
        {
            desiredVelocity = desiredDirection * maxSpeed * Time.fixedDeltaTime;
        }

        Vector2 steer = desiredVelocity - thisRigidbody.velocity;
        steer = Vector2.ClampMagnitude(steer, maxForce);
        return steer;
    }

    public void IncreaseMoveSpeed()
    {
        maxForce += maxForceIncrease;
        maxSpeed += maxSpeedIncrease;
    }

    public void DecreaseMoveSpeed()
    {
        maxForce -= maxForceDecrease;
        maxSpeed -= maxSpeedDecrease;
    }
}
