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
        Debug.LogWarning("SET DEAD ANIMATION PARAM USED");
        animator.SetBool("IsDead", true);
    }

    public void SetAttacking(bool isAttacking)
    {
        Debug.LogWarning("SET ATTACKING ANIMATION PARAM USED");
        animator.SetBool("IsAttacking", isAttacking);
    }

    public void SetMovementSpeed(float movementSpeed)
    {
        Debug.LogWarning("SET MOVEMENT ANIMATION PARAM USED");
        animator.SetFloat("MovementSpeed", movementSpeed);
    }

}
