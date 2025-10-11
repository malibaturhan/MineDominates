using System;
using System.Linq;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerIKControl : MonoBehaviour
{
    public Transform LeftHandIKTarget;
    public Transform RightHandIKTarget;
    public Transform LeftElbowIKTarget;
    public Transform RightElbowIKTarget;

    [Range(0, 1f)]
    public float HandIKAmount = 1f;
    [Range(0, 1f)]
    public float ElbowIKAmount = 1f;

    [SerializeField]private Animator Animator;


    private void OnAnimatorIK(int layerIndex)
    {
        if (LeftHandIKTarget != null)
        {
            Animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, HandIKAmount);
            Animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, HandIKAmount);
            Animator.SetIKPosition(AvatarIKGoal.LeftHand, LeftHandIKTarget.position);
            Animator.SetIKRotation(AvatarIKGoal.LeftHand, LeftHandIKTarget.rotation);
        }
        if (RightHandIKTarget != null)
        {
            Animator.SetIKPositionWeight(AvatarIKGoal.RightHand, HandIKAmount);
            Animator.SetIKRotationWeight(AvatarIKGoal.RightHand, HandIKAmount);
            Animator.SetIKPosition(AvatarIKGoal.RightHand, RightHandIKTarget.position);
            Animator.SetIKRotation(AvatarIKGoal.RightHand, RightHandIKTarget.rotation);
        }
        if (LeftElbowIKTarget != null)
        {
            Animator.SetIKHintPosition(AvatarIKHint.LeftElbow, LeftElbowIKTarget.position);
            Animator.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, ElbowIKAmount);
        }
        if (RightElbowIKTarget != null)
        {
            Animator.SetIKHintPosition(AvatarIKHint.RightElbow, RightElbowIKTarget.position);
            Animator.SetIKHintPositionWeight(AvatarIKHint.RightElbow, ElbowIKAmount);
        }
    }

    public void Setup(Transform GunParent)
    {
        Transform[] allChildren = GunParent.GetComponentsInChildren<Transform>();
        LeftElbowIKTarget = allChildren.FirstOrDefault(child => child.name == "LeftElbow");
        RightElbowIKTarget = allChildren.FirstOrDefault(child => child.name == "RightElbow");
        LeftHandIKTarget = allChildren.FirstOrDefault(child => child.name == "LeftHand");
        RightHandIKTarget = allChildren.FirstOrDefault(child => child.name == "RightHand");
    }

    internal void SetGunHandling(bool is1Handed)
    {
        Animator.SetBool("Is1HandedGun", is1Handed);
        Animator.SetBool("Is2HandedGun", !is1Handed);
        Debug.Log("Gun handling set at IK controller 1handed: " + is1Handed);
    }
}
