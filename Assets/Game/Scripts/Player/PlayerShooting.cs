using System;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("***Elements***")]
    PlayerController playerController;
    Transform cameraTransform;
    [SerializeField] private Transform gunTransform;
    [SerializeField] private Transform aimTarget;
    [SerializeField] private LayerMask aimLayerMask;
    [SerializeField] private PlayerIKControl playerIKControl;
    private bool currentlyAiming = false;
    private bool canShoot = true;       // Currently just exists - nothing manipulates it

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        cameraTransform = Camera.main.transform;
        SubscribeEvents();
        HandleAiming(currentlyAiming);
    }

    private void SubscribeEvents()
    {
        PlayerInputManager.PlayerAimingEvent += HandleAiming;
        //PlayerInputManager.PlayerShootingEvent += HandleShooting;
    }

    private void HandleAiming(bool isAiming)
    {
        if (isAiming) 
        {
            SetGunVisibility(true);
            playerIKControl.HandIKAmount = 1;
            playerIKControl.ElbowIKAmount = 1;
        }
        else
        {
            SetGunVisibility(false);
            playerIKControl.HandIKAmount = 0;
            playerIKControl.ElbowIKAmount = 0;
        }

    }

    private void SetGunVisibility(bool isGunVisible)
    {
        gunTransform.gameObject.SetActive(isGunVisible);
    }

    //private void HandleShooting(bool isShooting)
    //{
    //    if (currentlyAiming && isShooting)
    //    {
    //        TryShoot();
    //    }
    //    else
    //    {
    //        return;
    //    }
    //}

    //private void TryShoot()
    //{
    //    if (canShoot)
    //    {
    //        PlayShootingSound();
    //    }
    //    RaycastHit hit;
    //    if(Physics.Raycast(transform.position, aimTarget.position, out hit))
    //    {

    //    }
    //}

    //private void PlayShootingSound()
    //{
    //    Debug.Log("Gun shooting sound!!!!!!!!!!!!!!");
    //}


    // Update is called once per frame
    void Update()
    {
        //Debug.Log("AIM DIRECTION: " + GetForwardDirection(aimTarget));
        PlaceAim(GetForwardDirection(cameraTransform));
    }

    private void PlaceAim(Vector3 aimPosition)
    {
        RaycastHit raycastHit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out raycastHit, int.MaxValue, aimLayerMask))
        {
            aimTarget.position = raycastHit.point;
        }
        else
        {
            return;
        }
    }

    private Vector3 GetForwardDirection(Transform targetTransform)
    {
        return targetTransform.position - cameraTransform.position;
    }

    private void OnDestroy()
    {
        UnsubscribeEvents();
    }

    private void UnsubscribeEvents()
    {
        PlayerInputManager.PlayerAimingEvent   -= HandleAiming;
        //PlayerInputManager.PlayerShootingEvent -= HandleShooting;
    }
}
