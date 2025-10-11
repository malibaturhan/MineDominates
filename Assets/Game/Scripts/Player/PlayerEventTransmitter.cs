using System;
using System.Collections;
using UnityEngine;

public class PlayerEventTransmitter : MonoBehaviour
{
    public static Action<bool, Transform> IsPlayerInScene;
    private void Start()
    {
        StartCoroutine("InvokePlayerExistence");        
    }

    IEnumerator InvokePlayerExistence()
    {
        yield return null;
        IsPlayerInScene?.Invoke(true, transform);
        Debug.LogWarning("Player is in scene");
    }
    private void OnDisable()
    {
        IsPlayerInScene?.Invoke(false, transform);
        Debug.LogWarning("Player NOT in scene");
    }
}
