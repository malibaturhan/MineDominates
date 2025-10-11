using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("***Settings***")]
    [SerializeField] private bool Is1Handed = false;
    [Header("***Elements***")]
    PlayerIKControl playerIKControl;
    private bool isGunActive = true;
    private void Awake()
    {
        PlayerEventTransmitter.IsPlayerInScene += HandlePlayer;
    }

    private void HandlePlayer(bool isPlayerInScene, Transform playerTransform)
    {
        playerIKControl = playerTransform.GetComponent<PlayerIKControl>();
        playerIKControl.Setup(transform);
        playerIKControl.SetGunHandling(Is1Handed);
        Debug.Log($"{gameObject.name} get the IK controller");
    }

    private void OnDestroy()
    {
        PlayerEventTransmitter.IsPlayerInScene -= HandlePlayer;
    }
}
