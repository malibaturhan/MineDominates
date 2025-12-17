using UnityEngine;
using System.Collections;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup gameOverCanvasGroup;
    [SerializeField] private float fadeDuration = 0.2f;
    [SerializeField] private GameManager gameManager;
    void Start()
    {
        SubscribeEvents();
        gameOverCanvasGroup.alpha = 0f;
        gameOverCanvasGroup.gameObject.SetActive(false);
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
        GameManager.TransmitGameState -= HandlePause;
    }
    private void HandlePause(GameStateEnums gameState)
    {
        if (gameState == GameStateEnums.MAINMENU)
        {
            gameOverCanvasGroup.gameObject.SetActive(false);
        }
        if (gameState == GameStateEnums.PLAYING)
        {
            gameOverCanvasGroup.gameObject.SetActive(false);
            Time.timeScale = 1f;
            StartCoroutine(FadePanel(0f));
        }
        if (gameState == GameStateEnums.PAUSED)
        {
            gameOverCanvasGroup.gameObject.SetActive(false);
            Time.timeScale = 0f;
            StartCoroutine(FadePanel(1f));
        }
        if (gameState == GameStateEnums.GAMEOVER)
        {
            gameOverCanvasGroup.gameObject.SetActive(true);
            Time.timeScale = 0f;
            StartCoroutine(FadePanel(1f));
        }
    }

    private IEnumerator FadePanel(float targetAlpha)
    {
        var t = 0f;
        var startAlpha = gameOverCanvasGroup.alpha;
        while (t < fadeDuration)
        {
            var aimAlpha = Mathf.Lerp(startAlpha, targetAlpha, t / fadeDuration);
            gameOverCanvasGroup.alpha = aimAlpha;
            t += Time.unscaledDeltaTime;
            yield return null;
        }
        gameOverCanvasGroup.alpha = targetAlpha;
    }
}
