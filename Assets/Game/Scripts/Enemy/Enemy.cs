using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("***Settings***")]
    [SerializeField] private int health = 100;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private float attackRange = 2f;

    [Header("***Settings***")]
    [SerializeField] private Transform? playerTransform;

    protected IEnemyState currentState;

    private void Start()
    {
        PlayerEventTransmitter.IsPlayerInScene += HandlePlayerExistence;
    }

    private void HandlePlayerExistence(bool isPlayerInScene, Transform _playerTransform)
    {
        playerTransform = _playerTransform;

    }

    void Update()
    {
        if(currentState != null)
        {
            currentState.Update(this);
        }
    }

    public void ChangeState(IEnemyState newState)
    {
        if(currentState is not null) 
        {
            currentState.Exit(this);
        }

        currentState = newState;

        if (currentState != null) 
        {
            currentState.Enter(this);
        }

    }

    public virtual void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
            Die();
    }

    protected virtual void Die()
    {
        ChangeState(new DeadState());
        // burada animasyon, loot, destroy vs. tetiklenir
    }
}
