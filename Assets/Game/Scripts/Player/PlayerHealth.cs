using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("***Settings***")]
    [SerializeField] private float baseHealth = 100;
    [SerializeField] private float currentHealth = 100;

    [Header("***UI Elements***")]
    [SerializeField] private Image healthBar;
    [SerializeField] private PlayerSoundManager playerSoundManager;

    private void Start()
    {
        playerSoundManager = GetComponent<PlayerSoundManager>();
    }
    public void TakeHit(float damageValue)
    {
        currentHealth -= damageValue;
        CheckIfDie();
        UpdateUI();
    }

    private void CheckIfDie()
    {
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameManager.Instance.SetGameState(GameStateEnums.GAMEOVER);
    }

    private void UpdateUI()
    {
        if (healthBar != null)
        {
            var fillAmount = currentHealth / baseHealth;
            healthBar.fillAmount = fillAmount;
        }
    }
}
