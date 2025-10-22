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
        UpdateUI();
    }

    private void UpdateUI()
    {
        var fillAmount = currentHealth / baseHealth;
        healthBar.fillAmount = fillAmount;
    }
}
