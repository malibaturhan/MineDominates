using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerController playerController;

    [Header("***Settings***")]
    private Vector3 movementVector = Vector3.zero;
    void Start()
    {
        SubscribePlayerAnimEvents();
    }

    private void SubscribePlayerAnimEvents()
    {
        playerController.PlayerMovementMagnitudeAnimEvent += HandlePlayerMovement;
        playerController.PlayerJumpingAnimEvent += HandleJump;
        playerController.PlayerRunningAnimEvent += HandleRunning;
        playerController.PlayerAimingAnimEvent += HandlePlayerAiming;
        playerController.PlayerUsingRemoteAnimEvent += HandleRemoteUsing;
    }

    private void HandleRemoteUsing(bool isRemoteUse)
    {

    }

    private void HandlePlayerAiming(bool isAiming)
    {

    }

    private void HandleRunning(bool isRunning)
    {
        Debug.Log("RUN anim func trig " + isRunning);
        animator.SetBool("isRunning", isRunning);
    }

    private void HandleJump()
    {
        // FIX FIX FIX FIX FIX FIX
        //animator.SetBool("isRunning", isRunning);
    }

    private void HandlePlayerMovement(float moveMagnitude)
    {
        Debug.Log("movement anim func trig");
        animator.SetFloat("MovementSpeed", moveMagnitude);
    }


    private void OnDestroy()
    {
        playerController.PlayerMovementMagnitudeAnimEvent -= HandlePlayerMovement;
        playerController.PlayerJumpingAnimEvent -= HandleJump;
        playerController.PlayerRunningAnimEvent -= HandleRunning;
        playerController.PlayerAimingAnimEvent -= HandlePlayerAiming;
        playerController.PlayerUsingRemoteAnimEvent -= HandleRemoteUsing;
    }
}
