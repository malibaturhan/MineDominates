using System;
using System.Collections;
using UnityEngine;

public class PlayerEventTransmitter : MonoBehaviour
{
    public static Action<bool, Transform> IsPlayerInScene;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void ResetStatics()
    {
        IsPlayerInScene = null;
    }
    private void Start()
    {
        //IsPlayerInScene?.Invoke(true, gameObject.transform);
        StartCoroutine("InvokePlayerExistence");
        Debug.Log($"<color=yellow>[PlayerEventTransmitter]</color> Subscribers: {(IsPlayerInScene == null ? "None" : IsPlayerInScene.GetInvocationList().Length.ToString())}");
        Debug.Log($"<color=orange>[PlayerEventTransmitter]</color> Instance: {GetInstanceID()} Subscribers: {(IsPlayerInScene == null ? "None" : IsPlayerInScene.GetInvocationList().Length.ToString())}");

    }

    IEnumerator InvokePlayerExistence()
    {
        yield return null;
        Debug.Log($"<color=cyan>[PlayerEventTransmitter]</color> Invoking from {GetInstanceID()}");
        IsPlayerInScene?.Invoke(true, transform);
        Debug.LogWarning("Player is in scene");
    }
    private void OnDisable()
    {
        IsPlayerInScene?.Invoke(false, transform);
        Debug.LogWarning("Player NOT in scene");
    }
}
