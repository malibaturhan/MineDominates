using UnityEngine;
using UnityEngine.InputSystem;

public class GeneralInteractionHandler : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [Header("***General Keys***")]
    [SerializeField] private Key pauseKey = Key.Escape;
    void Start()
    {
        SubscribeEvents();
    }

    private void Update()
    {
        if (Keyboard.current == null)
        {
            Debug.LogWarning("Keyboard.current is NULL!");
            return;
        }

        if (Keyboard.current[pauseKey].wasPressedThisFrame)
        {
            if (gameManager.GetGameState() == GameStateEnums.PLAYING)
            {
                gameManager.SetGameState(GameStateEnums.PAUSED);
            }
            if (gameManager.GetGameState() == GameStateEnums.PAUSED)
            {
                gameManager.SetGameState(GameStateEnums.PLAYING);
            }
        }
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    private void SubscribeEvents()
    {
        GameManager.LinkGameManager += GetGameManager;
    }

    private void GetGameManager(GameManager manager)
    {
        gameManager = manager;
    }

    private void UnsubscribeEvents()
    {
        GameManager.LinkGameManager -= GetGameManager;
    }



}
