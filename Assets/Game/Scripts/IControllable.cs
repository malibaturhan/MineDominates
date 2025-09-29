using UnityEngine;

public interface IControllable
{
    void ProcessMovement(Vector3 moveInput);

    void OnJump();
    void OnAction1();
    void OnAction2();
    void OnRun(bool value);
       
}
