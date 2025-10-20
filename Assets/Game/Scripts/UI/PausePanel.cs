using System;
using System.Collections;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup pauseCanvasGroup;
    [SerializeField] private float fadeDuration = 0.2f;
    [SerializeField] private GameManager gameManager;
    void Start()
    {
        SubscribeEvents();
        pauseCanvasGroup.alpha = 0f;
        pauseCanvasGroup.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    private void SubscribeEvents()
    {
        GameManager.LinkGameManager += GetGameManager;
        GameManager.TransmitGameState += HandlePause;
    }

    private void GetGameManager(GameManager manager)
    {
        gameManager = manager;
    }

    private void UnsubscribeEvents()
    {
        GameManager.LinkGameManager -= GetGameManager;
        GameManager.TransmitGameState += HandlePause;
    }
    private void HandlePause(GameStateEnums gameState)
    {
        if (gameState == GameStateEnums.MAINMENU) 
        {
            pauseCanvasGroup.gameObject.SetActive(false);
        }
        if (gameState == GameStateEnums.PLAYING) 
        {
            pauseCanvasGroup.gameObject.SetActive(false);
            Time.timeScale = 1f;
            StartCoroutine(FadePanel(0f));
        }
        if (gameState == GameStateEnums.PAUSED) 
        {
            pauseCanvasGroup.gameObject.SetActive(true);
            Time.timeScale = 0f;
            StartCoroutine(FadePanel(1f));
        }
    }

    private IEnumerator FadePanel(float targetAlpha)
    {
        var t = 0f;
        var startAlpha = pauseCanvasGroup.alpha;    
        while (t < fadeDuration) 
        {
            var aimAlpha = Mathf.Lerp(startAlpha, targetAlpha, t / fadeDuration); 
            pauseCanvasGroup.alpha = aimAlpha;
            t += Time.unscaledDeltaTime;
            yield return null;
        }
        pauseCanvasGroup.alpha = targetAlpha;
    }
}
