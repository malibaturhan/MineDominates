using UnityEngine;

public class EnemyAnimAttackHandler : MonoBehaviour
{
    [Header("***Elements***")]
    [SerializeField] private Enemy enemy;
    [SerializeField] private PlayerHealth playerHealth;


    private void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();
    }

    // THIS IS CALLED FROM ANIMATION EVENT FROM PUNCH ANIMATION
    public void HitPlayer()
    {
        playerHealth.TakeHit(enemy.attackPower);
        //Debug.LogWarning("<<<<<<<<<<<< HIT PLAYER WORKDS");
    }
}
