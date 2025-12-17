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
        if (Instance != null && Instance != this)
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

        Debug.LogWarning("Game state changed to: " +newState);
        _gameState = newState;
        TransmitGameState?.Invoke(_gameState);
        if (GameStateEnums.MAINMENU == newState || GameStateEnums.PAUSED == newState || GameStateEnums.GAMEOVER == newState)
        {
            EnableMouse();
        }
        else
        {
            DisableMouse();
            Debug.LogWarning("MOUSE DISABLED");
        }
    }
    public GameStateEnums GetGameState()
    {
        return _gameState;
    }

    private void DisableMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void EnableMouse()
    {
        Cursor.lockState = CursorLockMode.None;
    }

}
