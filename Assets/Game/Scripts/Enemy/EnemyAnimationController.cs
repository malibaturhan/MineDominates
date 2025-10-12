using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetDead()
    {
        animator.SetBool("IsDead", true);
    }

    public void SetAttacking(bool isAttacking)
    {
        animator.SetBool("IsAttacking", isAttacking);
    }

    public void SetMovementSpeed(Vector3 movementVector)
    {
        var movementSpeed = movementVector.magnitude;
        animator.SetFloat("MovementSpeed", movementSpeed);
    }

}
