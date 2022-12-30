using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidController : MonoBehaviour
{
    [Range(1f, 10f)]
    [SerializeField] private float maxSpeed = 1;
    [Range(1f, 10f)]
    [SerializeField] private float maxTurnSpeed = 1;

    private float speed = 1;
    private float turnSpeed = 5;

    void Update()
    {
        ComputeNewAngle();
        ComputeNewPosition();
    }

    private void ComputeNewPosition()
    {
        transform.position += (speed * Time.deltaTime) * transform.up;
    }

    private void ComputeNewAngle()
    {
        transform.eulerAngles += (turnSpeed * Time.deltaTime) * transform.forward;
    }
}
