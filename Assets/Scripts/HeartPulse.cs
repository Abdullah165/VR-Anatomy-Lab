using LitMotion;
using LitMotion.Extensions;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class HeartPulse : MonoBehaviour
{
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private float scaleFactor = 1.2f;
    [SerializeField] private XRGrabInteractable interactable;

    private MotionHandle tween;
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;

        if (interactable != null)
        {

            interactable.selectEntered.AddListener(OnGrab);
            interactable.selectExited.AddListener(OnRelease);
        }

        StartPulse();
    }

    void StartPulse()
    {
        tween = LMotion.Create(originalScale, originalScale * scaleFactor, duration)
            .WithEase(Ease.OutBack)
            .WithLoops(-1, LoopType.Yoyo)
            .BindToLocalScale(transform);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        if (args.interactorObject is XRSocketInteractor) return;

        if (tween.IsActive()) tween.Cancel();
        transform.localScale = originalScale;
    }

    void OnRelease(SelectExitEventArgs args)
    {
        if (args.interactorObject is XRSocketInteractor) return;

        StartPulse();
    }
}