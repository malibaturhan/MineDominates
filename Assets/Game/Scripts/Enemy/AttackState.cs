using UnityEngine;


public class AttackState : IEnemyState
{
    public void Enter(Enemy enemy)
    {
        //Debug.Log($"{enemy.gameObject.name} entered Attack state");
        SetAnimatorParameters(enemy);
    }
    public void SetAnimatorParameters(Enemy enemy)
    {
        enemy.animationController.SetAttacking(true);
        enemy.animationController.SetMovementSpeed(0f);
    }
    public void Update(Enemy enemy)
    {
        if (enemy.PlayerTransform is null)
        {
            return;
        }
        if (!EnemyUtils.CheckPlayerDistance(enemy.PlayerTransform, enemy.transform, enemy.detectionRange))
        {
            Debug.LogWarning("Attack triggered chase");
            enemy.ChangeState(new ChaseState());
        }
    }

    public void Exit(Enemy enemy)
    {
    }


}
