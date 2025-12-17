using UnityEngine;

public class MainMenuDebugger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("GameManager: " + GameManager.Instance);
        Debug.Log("SceneLoader: " + SceneLoader.Instance);
        Debug.Log("TimeScale: " + Time.timeScale);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
