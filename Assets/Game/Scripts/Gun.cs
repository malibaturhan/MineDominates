using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    PlayerIKControl playerIKControl;
    private void Start()
    {
        PlayerEventTransmitter.IsPlayerInScene += HandlePlayer;
    }

    private void HandlePlayer(bool isPlayerInScene, Transform playerTransform)
    {
        playerIKControl = playerTransform.GetComponent<PlayerIKControl>();
        playerIKControl.Setup(this.transform);
        Debug.Log($"{gameObject.name} get the IK controller");
    }

    private void OnDestroy()
    {
        PlayerEventTransmitter.IsPlayerInScene -= HandlePlayer;
    }
}
