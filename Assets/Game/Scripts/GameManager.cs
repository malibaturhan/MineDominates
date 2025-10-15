using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [Header("SINGLETON INSTANCE")]
    public static GameManager Instance { get; private set; }

    [Header("***Elements***")]
    [SerializeField] private GameStateEnums _gameState;
    private void Awake()
    {
        if(Instance is not null && Instance == this.gameObject)
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
        GameRuns();
    }

    // Update is called once per frame
    void Update()
    {
        
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
