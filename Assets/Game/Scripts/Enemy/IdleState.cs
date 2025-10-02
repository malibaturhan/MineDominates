using UnityEngine;


public class IdleState : IEnemyState
{
    public void Enter(Enemy enemy)
    {
        Debug.Log($"{enemy.gameObject.name} entered idle state");
    }

    public void Update(Enemy enemy)
    {
        //if (EnemyUtils.CheckPlayerDistance(playerTransform, enemyTransform, 10))
        //{
        //    enemy.ChangeState(new ChaseState());
        //}
    }

    public void Exit(Enemy enemy)
    {
        throw new System.NotImplementedException();
    }


}
