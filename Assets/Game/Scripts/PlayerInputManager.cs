using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    [Header("***Settings***")]
    [SerializeField] private Key interactionKey = Key.E;
    [SerializeField] private Key secondaryInteractionKey = Key.Q;
    [SerializeField] private Key activateCarKey = Key.G;
    [SerializeField] private Key jumpKey = Key.Space;
    [SerializeField] private Key runKey = Key.LeftShift;

    [Header("***Events***")]
    public static Action<UnityEngine.Vector3> PlayerMovementInputEvent;
    public static Action PlayerJumpEvent; // Corresponds "Space" key
    public static Action<bool> PlayerRunEvent; // Corresponds "Space" key
    public static Action PlayerInteractionEvent; // Corresponds "E" key
    public static Action PlayerSecondaryInteractionEvent; // Corresponds "Q" key
    public static Action<bool> ActivateCarEvent; // Corresponds "G" key

    [Header("***Elements***")]
    [SerializeField] private PlayerAnimator playerAnimator;
    [SerializeField] private PlayerIKControl playerIKControl;
    [SerializeField] private InputRouter inputRouter;


    [Header("***Controllables***")]
    [SerializeField] private PlayerController player;
    [SerializeField] private RCVehicle rcCar;

    [Header("***Cameras***")]
    [SerializeField] private CinemachineCamera playerCam;
    [SerializeField] private CinemachineCamera rcCarCam;
    void Start()
    {
        inputRouter.CurrentTarget = player;
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
            PlayerJumpEvent?.Invoke();
        }
        if (Keyboard.current[runKey].wasPressedThisFrame)
        {
            PlayerRunEvent?.Invoke(true);
        }
        if (Keyboard.current[runKey].wasReleasedThisFrame)
        {
            PlayerRunEvent?.Invoke(false);
        }
        if (Keyboard.current[activateCarKey].wasPressedThisFrame)
        {
            if (inputRouter.CurrentTarget == rcCar)
            {
                inputRouter.CurrentTarget = player;
                SetActiveCamera(playerCam);
                return;
            }

            if (inputRouter.CurrentTarget == player)
            {
                inputRouter.CurrentTarget = rcCar;
                SetActiveCamera(rcCarCam);
                return;
            }
        }
        movementVector = movementVector.normalized;
        PlayerMovementInputEvent?.Invoke(movementVector);
        //Debug.Log("Movement Vector: " + movementVector);
    }

    private void SetActiveCamera(CinemachineCamera activeCam)
    {
        playerCam.gameObject.SetActive(false);
        rcCarCam.gameObject.SetActive(false);
        activeCam.gameObject.SetActive(true);
    }
}
