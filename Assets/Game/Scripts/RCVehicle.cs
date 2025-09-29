using UnityEngine;

public class RCVehicle : MonoBehaviour, IControllable
{
    [Header("Car Properties")]
    public float motorTorque = 2000f;
    public float brakeTorque = 2000f;
    public float maxSpeed = 20f;
    public float steeringRange = 30f;
    public float steeringRangeAtMaxSpeed = 10f;

    [Header("***Elements***")]
    private Rigidbody rigidbody;
    [SerializeField] private AxleManager frontAxleMan;
    [SerializeField] private AxleManager rearAxleMan;
    [SerializeField] private WheelControl[] wheels;
    float vInput = 0;
    float hInput = 0;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        wheels = GetComponentsInChildren<WheelControl>();
    }

    private void FixedUpdate()
    {

        float forwardSpeed = Vector3.Dot(transform.forward, rigidbody.linearVelocity);
        float speedFactor = Mathf.InverseLerp(0, maxSpeed, Mathf.Abs(forwardSpeed)); // Normalized speed factor

        float currentMotorTorque = Mathf.Lerp(motorTorque, 0, speedFactor);
        float currentSteerRange = Mathf.Lerp(steeringRange, steeringRangeAtMaxSpeed, speedFactor);

        // Determine if the player is accelerating or trying to reverse
        bool isAccelerating = Mathf.Sign(vInput) == Mathf.Sign(forwardSpeed);

        foreach (var wheel in wheels)
        {
            // Apply steering to wheels that support steering
            if (wheel.steerable)
            {
                wheel.WheelCollider.steerAngle = hInput * currentSteerRange;
            }

            if (isAccelerating)
            {
                // Apply torque to motorized wheels
                if (wheel.motorized)
                {
                    wheel.WheelCollider.motorTorque = vInput * currentMotorTorque;
                }
                // Release brakes when accelerating
                wheel.WheelCollider.brakeTorque = 0f;
            }
            else
            {
                // Apply brakes when reversing direction
                wheel.WheelCollider.motorTorque = 0f;
                wheel.WheelCollider.brakeTorque = Mathf.Abs(vInput) * brakeTorque;
            }
        }
    }
    public void ProcessMovement(Vector3 moveInput)
    {
        vInput = moveInput.z;
        hInput = moveInput.x;
        Debug.Log("Car process movement :" + moveInput);
    }

    public void OnAction1()
    {
        
    }

    public void OnAction2()
    {
        
    }

    public void OnJump()
    {
        
    }

    public void OnRun(bool value)
    {
        
    }
}
