using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject winPanel;

    [SerializeField] List<Enemy> enemies = new();

    public static LevelManager Instance { get; private set; }

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

    }

    private void OnEnable()
    {
        SceneManager.activeSceneChanged += OnSceneChangeCallback;
    }
    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= OnSceneChangeCallback;
    }

    private void OnSceneChangeCallback(Scene currentScene, Scene nextScene)
    {
        if (nextScene.buildIndex == 0)
        {
            GameManager.Instance.SetGameState(GameStateEnums.MAINMENU);

        }
        else
        {
            if (winPanel == null)
            {
                winPanel = FindFirstObjectByType<WinPanel>().gameObject;
            }
            winPanel.SetActive(false);
        }
    }

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }
    public void RemoveEnemy(Enemy enemy)
    {
        enemies.Remove(enemy);
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if (enemies.Count <= 0)
        {
            if (winPanel == null) return;
            winPanel.SetActive(true);
        }
    }
}
