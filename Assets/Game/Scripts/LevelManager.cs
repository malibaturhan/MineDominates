using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject winPanel;

    List<Enemy> enemies = new();

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
        winPanel.SetActive(false);
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
        if(enemies.Count <= 0)
        {
            winPanel.SetActive(true);
        }
    }
}
