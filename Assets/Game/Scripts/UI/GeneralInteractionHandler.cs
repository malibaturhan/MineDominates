using UnityEngine;
using UnityEngine.InputSystem;

public class GeneralInteractionHandler : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [Header("***General Keys***")]
    [SerializeField] private Key interactionKey = Key.Escape;
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
    

}
