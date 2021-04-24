using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float maxSpeed = 100;
    [SerializeField] float maxForce = 10;
    [SerializeField] float slowingRadius = 2f;

    private Vector2 targetPosition;
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

        thisRigidbody.AddForce(seek, ForceMode2D.Impulse);
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

    public void IncreaseMoveSpeed(float maxForceIncrease, float maxSpeedIncrease)
    {
        maxForce += maxForceIncrease;
        maxSpeed += maxSpeedIncrease;
    }
}
