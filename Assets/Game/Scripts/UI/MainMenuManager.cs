using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("***Elements***")]
    [SerializeField] private GameObject optionsPanel;

    [Header("***Buttons***")]


    [Header("***Settings***")]
    [SerializeField] private bool isOptionsPanelActive = false;


    public void OnPlayClicked() => SceneLoader.Instance.LoadLevelAsync("Level1");
    public void OnQuitClicked() => Application.Quit();

}
