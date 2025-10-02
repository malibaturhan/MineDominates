using Unity.VisualScripting;
using UnityEngine;

public class ChaseState : IEnemyState
{
    public void Enter(Enemy enemy)
    {
        
    }
    public void Update(Enemy enemy)
    {
        //if (EnemyUtils.CheckPlayerDistance())
        //{
        //    enemy.ChangeState(new AttackState());
        //}
    }
    public void Exit(Enemy enemy)
    {
        
    }


}
