using UnityEngine;

public class AxleManager : MonoBehaviour
{
    [SerializeField] private WheelCollider[] managingWheels;

    private void Awake()
    {
        managingWheels = GetComponentsInChildren<WheelCollider>();
    }
    public void SetMotorized(bool value)
    {
        foreach(var wheel in managingWheels)
        {
            
        }
    }
    public void SetSteerable(bool value)
    {
        foreach(var wheel in managingWheels)
        {
            //wheel.steer
        }
    }


}
