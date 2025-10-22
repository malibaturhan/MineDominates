using UnityEngine;


public class AttackState : IEnemyState
{
    public void Enter(Enemy enemy)
    {
        //Debug.Log($"{enemy.gameObject.name} entered Attack state");
        SetAnimatorParameters(enemy);
        enemy.navigator.SetSpeed(enemy.attackWalkSpeed);
    }
    public void SetAnimatorParameters(Enemy enemy)
    {
        enemy.animationController.SetAttacking(true);
    }
    public void Update(Enemy enemy)
    {
        if (enemy.PlayerTransform is null)
            return;


        if (!EnemyUtils.CheckPlayerDistance(enemy.PlayerTransform, enemy.transform, enemy.detectionRange))
        {
            //Debug.LogWarning("Attack triggered chase");
            enemy.ChangeState(new ChaseState());
        }
        else
        {
            if (EnemyUtils.CheckPlayerDistance(enemy.PlayerTransform, enemy.transform, enemy.attackRange))
            {
                enemy.navigator.SetTarget(enemy.transform);
                enemy.navigator.SetSpeed(0f);
                //Debug.LogWarning("<<<<<<<<<<<<<<<<<<<<<<<< ENEMY IS NEAR ENOUGH TO STOP");
            }
            else
            {
                enemy.navigator.SetTarget(enemy.PlayerTransform);
                enemy.navigator.SetSpeed(enemy.attackWalkSpeed);
            }
        }
    }

    public void Exit(Enemy enemy)
    {
    }


}
