using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDebugUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI debugText;
    [SerializeField] private Enemy enemy;
    [SerializeField] private Image hpImage;

    void Update()
    {
        if (enemy != null)
        {
            debugText.text = $"State: {enemy.CurrentState}\nHP: {enemy.Health}";
            hpImage.fillAmount = enemy.Health / 100f;
        }
    }
}
