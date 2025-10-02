using System;
using UnityEngine;

public class PlayerEventTransmitter : MonoBehaviour
{
    public static Action<bool, Transform> IsPlayerInScene;
    private void Start()
    {
        IsPlayerInScene?.Invoke(true, this.transform);
    }
    private void OnDisable()
    {
        IsPlayerInScene?.Invoke(false, this.transform);
    }
}
