using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [Header("SINGLETON INSTANCE")]
    public static SceneLoader Instance { get; private set; }

    [Header("***UI Elements***")]
    [SerializeField] private CanvasGroup loadingCanvas;
    [SerializeField] private Slider progressBar;
    [SerializeField] private float fadeDuration = 0.5f;


    private void Awake()
    {
        if (Instance is not null && Instance == this.gameObject)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            loadingCanvas.alpha = 0f;
            loadingCanvas.gameObject.SetActive(false);
        }
    }
    public void LoadLevelAsync(string levelName)
    {
        StartCoroutine(LoadSceneCoroutine(levelName));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        loadingCanvas.gameObject.SetActive(true);
        yield return FadeCanvas(1f);

        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(sceneName);
        asyncOp.allowSceneActivation = false;

        while (!asyncOp.isDone)
        {
            float progress = Mathf.Clamp01(asyncOp.progress / 0.9f);
            if (progressBar is not null)
            {
                progressBar.value = progress;
            }
            if (asyncOp.progress >= 0.9f)
            {
                yield return new WaitForSeconds(0.4f);
                asyncOp.allowSceneActivation = true;
            }

            yield return null;
        }
        yield return FadeCanvas(0f);
        loadingCanvas.gameObject.SetActive(false);
    }


    private IEnumerator FadeCanvas(float targetAlpha)
    {
        float startAlpha = loadingCanvas.alpha;
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.unscaledDeltaTime;
            loadingCanvas.alpha = Mathf.Lerp(startAlpha, targetAlpha, t / fadeDuration);
            yield return null;
        }
        loadingCanvas.alpha = targetAlpha;
    }
}
