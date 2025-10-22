using Unity.VisualScripting;
using UnityEngine;

public class ChaseState : IEnemyState
{
    public void Enter(Enemy enemy)
    {
        //Debug.Log($"{enemy.gameObject.name} entered Chase state");
        SetAnimatorParameters(enemy);
        enemy.navigator.SetSpeed(enemy.chaseSpeed);
    }
    public void SetAnimatorParameters(Enemy enemy)
    {
        enemy.animationController.SetAttacking(false);
        enemy.animationController.SetMovementSpeed(enemy.navigator.Velocity);
    }
    public void Update(Enemy enemy)
    {
        if(enemy.PlayerTransform is null)
        {
            return;
        }
        if (EnemyUtils.CheckPlayerDistance(enemy.PlayerTransform, enemy.transform, enemy.attackRange))
        {
            Debug.Log("Chase state triggered attack");
            enemy.ChangeState(new AttackState());
        }
        else
        {
            enemy.navigator.SetTarget(enemy.PlayerTransform);
        }
    }
    public void Exit(Enemy enemy)
    {

    }


}
