using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Threading.Tasks;

public class SceneLoader : MonoBehaviour
{
    [Header("SINGLETON INSTANCE")]
    public static SceneLoader Instance { get; private set; }

    [Header("***UI Elements***")]


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
        }
    }
    public void LoadLevelAsync(string levelName)
    {
        
    }
}
