using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{

    public static Action<GameManager> LinkGameManager;
    public static Action<GameStateEnums> TransmitGameState;

    [Header("SINGLETON INSTANCE")]
    public static GameManager Instance { get; private set; }

    [Header("***Elements***")]
    [SerializeField] private GameStateEnums _gameState;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }
    void Start()
    {
        _gameState = GameStateEnums.MAINMENU;
        TransmitGameManager();
    }

    private void TransmitGameManager()
    {
        LinkGameManager?.Invoke(Instance);
    }

    public void SetGameState(GameStateEnums newState)
    {
        _gameState = newState;
        TransmitGameState?.Invoke(_gameState);
    }
    public GameStateEnums GetGameState()
    {
        return _gameState;
    }

    private void GameRuns()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void MenuActive()
    {
        Cursor.lockState = CursorLockMode.None;
    }

}
