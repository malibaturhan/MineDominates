using System;
using UnityEngine;

public class MainMenuUIController : MonoBehaviour
{
    [Header("***Elements***")]
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameManager gameManager;

    [Header("***Buttons***")]


    [Header("***Settings***")]
    [SerializeField] private bool isOptionsPanelActive = false;

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        GameManager.LinkGameManager += GetGameManager;
    }

    private void GetGameManager(GameManager manager)
    {
        gameManager = manager;
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    private void UnsubscribeEvents()
    {
        GameManager.LinkGameManager -= GetGameManager;
    }

    public void OnPlayClicked()
    {
        gameManager.SetGameState(GameStateEnums.PLAYING);
        if (SceneLoader.Instance != null) 
        {
            SceneLoader.Instance.LoadLevelAsync("Level1");
        }
        else
        {
            Debug.LogError("Scene loader cannot be achieved");
        }
        
    }
    public void OnQuitClicked() => Application.Quit();
}
