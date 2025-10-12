using System;
using UnityEngine;

public class InputRouter : MonoBehaviour
{
    private IControllable _currentTarget;
    public IControllable CurrentTarget
    {
        get { return _currentTarget; }
        set
        {
            _currentTarget = value;
            //Debug.Log(value);
        }
    }
    private void OnEnable()
    {
        PlayerInputManager.PlayerMovementInputEvent += HandleMove;
        PlayerInputManager.PlayerJumpEvent += HandleJump;
        PlayerInputManager.PlayerInteractionEvent += HandleAction;
        PlayerInputManager.PlayerRunEvent += HandleRun;
    }


    private void OnDisable()
    {
        PlayerInputManager.PlayerMovementInputEvent -= HandleMove;
        PlayerInputManager.PlayerJumpEvent -= HandleJump;
        PlayerInputManager.PlayerInteractionEvent -= HandleAction; 
        PlayerInputManager.PlayerRunEvent -= HandleRun;
    }

    private void HandleMove(Vector3 movement) => CurrentTarget?.ProcessMovement(movement);
    private void HandleJump() => CurrentTarget?.OnJump();
    private void HandleRun(bool v) => CurrentTarget?.OnRun(v);
    private void HandleAction() => CurrentTarget?.OnAction1();
}
