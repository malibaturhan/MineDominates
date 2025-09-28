using System;
using UnityEngine;

public class PlayerController : MonoBehaviour, IControllable
{
    [Header("***Elements***")]
    CharacterController characterController;
    [SerializeField] private Transform cameraTransform;

    [Header("***Settings***")]
    [SerializeField]private float movementSpeed = 10;
    [SerializeField]private float rotationSpeed = 10;
    [SerializeField]private Vector3 verticalMovement = Vector3.zero;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravityForce = -10f;

    void Start()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        characterController = GetComponent<CharacterController>();
        SubscribeInputs();
    }


    private void SubscribeInputs()
    {
        PlayerInputManager.PlayerMovementInputEvent += ProcessMovement;
    }

    public void ProcessMovement(Vector3 movementVector)
    {
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;
        camForward.y = 0;
        camRight.y = 0;

        Vector3 move = camForward.normalized * movementVector.z + 
                        camRight.normalized * movementVector.x;

        if(move.magnitude > 0.1f) 
        {
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        Vector3 horizontalMove = move * movementSpeed;

        if (IsGrounded && verticalMovement.y < 0)
        {
            verticalMovement.y = -2f;
        }
        verticalMovement.y += gravityForce * Time.deltaTime;

        Vector3 finalMove = (horizontalMove + verticalMovement) * Time.deltaTime;
        characterController.Move(finalMove);
    }

    private void ProcessJump()
    {
        if (IsGrounded)
        {
            // zýplama hýzýný hesapla (fizik formülü: v = sqrt(2 * h * g))
            verticalMovement.y = Mathf.Sqrt(jumpHeight * -2f * gravityForce);
        }
    }

    private void OnDestroy()
    {
        UnsubscribeInputs();
    }

    private void UnsubscribeInputs()
    {
        PlayerInputManager.PlayerMovementInputEvent -= ProcessMovement;
    }


    public void OnJump()
    {

    }

    public void OnAction1()
    {
       
    }

    public void OnAction2()
    {
        
    }

    private bool IsGrounded => characterController.isGrounded;
}
