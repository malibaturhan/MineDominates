using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameRuns();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GameRuns()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void MenuActive()
    {
        Cursor.lockState = CursorLockMode.None;
    }

}
