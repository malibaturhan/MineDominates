using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("***Settings***")]
    [SerializeField] private int health = 100;
    [SerializeField] public float detectionRange = 10f;
    public float attackRange = 2f;

    [Header("***Settings***")]
    [SerializeField] public Transform? PlayerTransform;

    [Header("***Elements***")]
    [HideInInspector]public EnemyNavigator navigator;
    public EnemyAnimationController animationController;

    [SerializeField] private IEnemyState currentState;
    public IEnemyState CurrentState => currentState;
    public int Health => health;

    private void Awake()
    {
        SetupNavigator();
        PlayerEventTransmitter.IsPlayerInScene += HandlePlayerExistence;
        ChangeState(new IdleState());
        //Debug.Log("subscribed player");
    }

    private void SetupNavigator()
    {
        navigator = GetComponent<EnemyNavigator>();
    }

    private void Start()
    {
        if (PlayerTransform is null) 
        {
            var p = FindFirstObjectByType<PlayerController>();
            PlayerTransform = p.transform;
        }
    }
    private void HandlePlayerExistence(bool isPlayerInScene, Transform _playerTransform)
    {
        PlayerTransform = _playerTransform;
        //Debug.Log("PLAYER TRANSFORM GRABBED");
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
        Debug.LogWarning("TAKE DAMAGE ON ENEMY triggered chase");
        ChangeState(new ChaseState());
        health -= amount;
        if (health <= 0)
            Die();
    }

    protected virtual void Die()
    {
        ChangeState(new DeadState());
        // burada animasyon, loot, destroy vs. tetiklenir
    }

    private void OnDisable()
    {
        PlayerEventTransmitter.IsPlayerInScene -= HandlePlayerExistence;
    }
}
