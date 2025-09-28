using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    [Header("***Settings***")]
    [SerializeField] private Key interactionKey = Key.E;
    [SerializeField] private Key secondaryInteractionKey = Key.Q;
    [SerializeField] private Key activateCarKey = Key.G;
    [SerializeField] private Key jumpKey = Key.Space;

    [Header("***Events***")]
    public static Action<UnityEngine.Vector3> PlayerMovementInputEvent;
    public static Action<bool> PlayerInteractionEvent; // Corresponds "E" key
    public static Action<bool> PlayerSecondaryInteractionEvent; // Corresponds "Q" key
    public static Action<bool> ActivateCarEvent; // Corresponds "G" key

    [Header("***Elements***")]
    [SerializeField] private PlayerAnimator playerAnimator;
    [SerializeField] private PlayerIKControl playerIKControl;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetMoveInputAndBroadcast();
    }

    private void GetMoveInputAndBroadcast()
    {
        Vector3 movementVector = Vector3.zero;
        if (Keyboard.current.wKey.isPressed) 
        {
            movementVector += Vector3.forward;
        }
        if (Keyboard.current.aKey.isPressed) 
        {
            movementVector += Vector3.left;
        }
        if (Keyboard.current.dKey.isPressed) 
        {
            movementVector += Vector3.right;
        }
        if (Keyboard.current.sKey.isPressed) 
        {
            movementVector += Vector3.back;
        }
        if (Keyboard.current[jumpKey].wasPressedThisFrame)
        {
            movementVector += Vector3.up;
        }
        movementVector = movementVector.normalized;
        PlayerMovementInputEvent?.Invoke(movementVector);
        Debug.Log("Movement Vector: " + movementVector);
    }
}
