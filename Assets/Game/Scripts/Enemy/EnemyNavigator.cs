using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigator : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] public float Velocity { get; private set; }
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float minVelocityForRotation = 0.1f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }

    public void SetTarget(Transform playerTransform)
    {
        agent.SetDestination(playerTransform.position);
    }

    public void SetSpeed(float speed) 
    {
        agent.speed = speed;
    }


    void FixedUpdate()
    {
        Velocity = agent.velocity.magnitude;
        //Debug.Log(Velocity);
        RotateTowardsMovementDirection();
    }

    private void RotateTowardsMovementDirection()
    {
        Vector3 vel = agent.velocity;
        vel.y = 0;

        if (vel.sqrMagnitude > Mathf.Pow(minVelocityForRotation, 2))
        {
            Vector3 dir = agent.velocity;
            Quaternion targetRot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
        }


    }
}
