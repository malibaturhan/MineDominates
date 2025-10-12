using System;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    Transform aimTarget;
    Transform playerTransform;

    [Header("***States***")]
    private bool isAiming;
    private bool isShooting;

    [Header("***Elements***")]
    [SerializeField] private Transform muzzleTransform;

    [Header("***Components***")]
    [SerializeField] private AudioSource gunAudioSource;
    [SerializeField] private GameObject bulletPrefab;

    [Header("***Settings***")]
    [SerializeField] private float fireRate = 4f;
    private float timeBetweenShots;
    private float timeSinceLastShot = 0;
    void Start()
    {
        timeBetweenShots = 1f / fireRate;
        SubscribeEvents();
        aimTarget = FindFirstObjectByType<AimTarget>().gameObject.transform;
        playerTransform = FindFirstObjectByType<PlayerController>().transform;
        gunAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        HandleAiming();
        HandleShooting();
        timeSinceLastShot += Time.deltaTime;
    }

    private void SubscribeEvents()
    {
        PlayerInputManager.PlayerAimingEvent += SetIsAiming;
        PlayerInputManager.PlayerShootingEvent += SetIsShooting;
    }

    private void SetIsAiming(bool obj) => isAiming = obj;
    private void SetIsShooting(bool obj) => isShooting = obj;

    private void HandleShooting()
    {
        if (isAiming && isShooting)
        {
            if (timeSinceLastShot > timeBetweenShots)
            {
                TryShoot();
                timeSinceLastShot = 0;
            }
        }
        return;
    }

    private void TryShoot()
    {
        gunAudioSource.Play();
        var bullet = Instantiate(bulletPrefab);
        bullet.transform.position = muzzleTransform.position;
        bullet.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
        bullet.transform.forward = muzzleTransform.forward;
    }

    private void HandleAiming()
    {
        transform.forward = aimTarget.position - transform.position;
        SetAimAnimations(isAiming);
    }

    private void SetAimAnimations(bool isAiming)
    {

    }
    private void UnsubscribeEvents()
    {
        PlayerInputManager.PlayerAimingEvent += SetIsAiming;
        PlayerInputManager.PlayerShootingEvent += SetIsShooting;
    }

    private void OnDestroy()
    {
        UnsubscribeEvents();
    }

}
