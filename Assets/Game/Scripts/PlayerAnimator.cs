using System;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [Header("***Settings***")]
    private Vector3 movementVector = Vector3.zero;
    void Start()
    {
        PlayerInputManager.PlayerMovementInputEvent += GetMovementVector;
    }

    private void GetMovementVector(Vector3 vector)
    {
        movementVector = vector;
    }

    // Update is called once per frame
    void Update()
    {
        AnimateMovement();
    }

    private void AnimateMovement()
    {
        if (movementVector.magnitude > 0) 
        {
            animator.SetFloat("MovementSpeed", movementVector.magnitude);
        }
    }
}
