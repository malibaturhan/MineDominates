using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("***Settings***")]
    [SerializeField] private int health = 100;
    [SerializeField] public float detectionRange = 10f;
    [SerializeField] public float chaseSpeed = 6f;
    [SerializeField] public float attackWalkSpeed = 4.5f;
    public float attackRange = 2f;
    public float attackPower = 5f;

    [Header("***Elements***")]
    [SerializeField] public Transform? PlayerTransform;
    [HideInInspector]public EnemyNavigator navigator;
    public EnemyAnimationController animationController;

    [SerializeField] private IEnemyState currentState;
    public IEnemyState CurrentState => currentState;
    public Action<IEnemyState> OnStateChange;
    public int Health => health;
    private bool isDead = false;

    private void Awake()
    {
        SetupNavigator();
        Debug.Log($"////////[{name}] subscribing to PlayerEventTransmitter ({GetInstanceID()})");
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
        //Debug.Log($"***[{name}] Player Transform assigned: {_playerTransform.position}");
        //Debug.Log("PLAYER TRANSFORM GRABBED");
    }

    void Update()
    {
        if(currentState != null)
        {
            currentState.Update(this);
        }
        //if (PlayerTransform == null)
        //    Debug.LogError($"[{name}] PlayerTransform is NULL!");

        //if (PlayerTransform != null && Vector3.Distance(PlayerTransform.position, transform.position) == 0)
        //    Debug.LogWarning($"[{name}] PlayerTransform same position as EnemyTransform!");
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
            OnStateChange?.Invoke(newState);
        }

    }

    public virtual void TakeDamage(int amount)
    {
        if (!isDead)
        {
            Debug.LogWarning("TAKE DAMAGE ON ENEMY triggered chase");
            ChangeState(new ChaseState());
            health -= amount;
            if (health <= 0)
            {
                Die();
                isDead = true;
            }
        }
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
