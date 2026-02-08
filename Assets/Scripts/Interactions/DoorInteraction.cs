using Interactions;
using DG.Tweening;
using UnityEngine;

public class DoorInteraction : InteractableBase
{
    [Header("Door Settings")] [SerializeField]
    private float openAngle = 90f;
    [SerializeField] private float openCloseSpeed = 6f;
    [SerializeField] private float openCloseDuration = 0.6f;
    [SerializeField] private Ease ease = Ease.OutQuad;
    
    
    private bool isOpen = false;
    private Quaternion closedRot;
    private Quaternion openRot;

    private Tween currentTween;
    void Awake()
    {
        closedRot = transform.rotation;
        openRot = closedRot * Quaternion.Euler(0f, openAngle, 0f);
    }
    
    protected override void PerformInteract()
    {
        isOpen = !isOpen;

        currentTween?.Kill();

        Quaternion target = isOpen ? openRot : closedRot;

        currentTween = transform
            .DORotateQuaternion(target, openCloseDuration)
            .SetEase(ease);

        Debug.Log(isOpen ? "Door Opened" : "Door closed");
    }
}