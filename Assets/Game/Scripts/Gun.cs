using System;
using System.Collections;
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
        //StartCoroutine("SubscribePlayer");
    }



    private IEnumerator SubscribePlayer()
    {
        yield return null;
    }

    //private void HandlePlayer(bool isPlayerInScene, Transform playerTransform)
    //{
    //    playerIKControl = playerTransform.GetComponent<PlayerIKControl>();
    //    playerIKControl.Setup(transform);
    //    playerIKControl.SetGunHandling(Is1Handed);
    //    Debug.Log($"{gameObject.name} get the IK controller");
    //}



    private void HandlePlayer(bool isPlayerInScene, Transform playerTransform)
    {

        var ik = playerTransform.GetComponent<PlayerIKControl>();
        var ikChild = playerTransform.GetComponentInChildren<PlayerIKControl>();

    }



    private void OnDestroy()
    {
        PlayerEventTransmitter.IsPlayerInScene -= HandlePlayer;
    }
}
