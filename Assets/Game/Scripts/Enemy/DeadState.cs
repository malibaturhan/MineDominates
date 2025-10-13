using UnityEngine;

public class DeadState : IEnemyState
{
    public void Enter(Enemy enemy)
    {
        //Debug.Log($"{enemy.gameObject.name} entered dead state");
        SetAnimatorParameters(enemy);
        enemy.navigator.SetTarget(enemy.transform);
        GameObject.Destroy(enemy.gameObject, 2f); // 2 sn sonra yok et
    }
    public void SetAnimatorParameters(Enemy enemy)
    {
        enemy.animationController.SetAttacking(false);
        enemy.animationController.SetDead();
        enemy.animationController.SetMovementSpeed(0f);
    }
    public void Update(Enemy enemy)
    {
        if (enemy.PlayerTransform is null)
        {
            return;
        }
    }
    public void Exit(Enemy enemy) { }
}
