using UnityEngine;

public class DeadState : IEnemyState
{
    public void Enter(Enemy enemy)
    {
        Debug.Log(enemy.name + " öldü.");
        GameObject.Destroy(enemy.gameObject, 2f); // 2 sn sonra yok et
    }

    public void Update(Enemy enemy) { }
    public void Exit(Enemy enemy) { }
}
