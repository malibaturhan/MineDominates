using UnityEngine;


public class IdleState : IEnemyState
{
    public void Enter(Enemy enemy)
    {
        //Debug.Log($"{enemy.gameObject.name} entered idle state");
        SetAnimatorParameters(enemy);

    }
    public void SetAnimatorParameters(Enemy enemy)
    {
        enemy.animationController.SetAttacking(false);
        enemy.animationController.SetMovementSpeed(0f);
    }
    public void Update(Enemy enemy)
    {
        if (enemy.PlayerTransform is null)
        {
            return;
        }
        if (EnemyUtils.CheckPlayerDistance(enemy.PlayerTransform, enemy.transform, enemy.detectionRange))
        {
            //Debug.LogWarning("IDLE triggered chase");
            enemy.ChangeState(new ChaseState());
        }
    }

    public void Exit(Enemy enemy)
    {
        
    }


}
