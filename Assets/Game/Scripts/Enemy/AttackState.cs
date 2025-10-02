using UnityEngine;


public class AttackState : IEnemyState
{
    public void Enter(Enemy enemy)
    {
        Debug.Log($"{enemy.gameObject.name} entered idle state");
    }

    public void Update(Enemy enemy)
    {
        //if (EnemyUtils.CheckForPlayer(playerTransform, enemyTransform))
        //{
        //    enemy.ChangeState(new ChaseState());
        //}
    }

    public void Exit(Enemy enemy)
    {
        throw new System.NotImplementedException();
    }


}
