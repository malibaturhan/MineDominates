using UnityEngine;

public class RCVehicle : MonoBehaviour, IControllable
{
    [Header("Car Properties")]
    public float motorTorque = 2000f;
    public float brakeTorque = 2000f;
    public float maxSpeed = 20f;
    public float steeringRange = 30f;
    public float steeringRangeAtMaxSpeed = 10f;

    public void ProcessMovement(Vector3 moveInput)
    {
        float vInput = moveInput.y;
        float hInput = moveInput.x;
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
