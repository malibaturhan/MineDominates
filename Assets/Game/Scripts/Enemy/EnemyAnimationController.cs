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
        //Debug.LogWarning("SET DEAD ANIMATION PARAM USED");
        animator.SetBool("IsDead", true);
        SetAttacking(false);
    }

    public void SetAttacking(bool isAttacking)
    {
        //Debug.LogWarning("SET ATTACKING ANIMATION PARAM USED");
        animator.SetBool("IsAttacking", isAttacking);
        if (isAttacking)
        {
            animator.SetTrigger("AttackTrigger");
        }
        else
        {
            animator.ResetTrigger("AttackTrigger");
        }
    }

    public void SetMovementSpeed(float movementSpeed)
    {
        //Debug.LogWarning("SET MOVEMENT ANIMATION PARAM USED");
        animator.SetFloat("MovementSpeed", movementSpeed);
        if (movementSpeed < 0.1f)
        {
            SetAttacking(false);
        }
    }

}
