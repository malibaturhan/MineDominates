using UnityEngine;

public class PauseMenuActions : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    void Start()
    {
        SubscribeEvents();
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
    public void Continue()
    {
        gameManager.SetGameState(GameStateEnums.PLAYING);
    }

}
