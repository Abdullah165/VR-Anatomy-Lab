using LitMotion;
using LitMotion.Extensions;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class OrganRotation : MonoBehaviour
{
    [SerializeField] private float rotationDuration = 2f;
    [SerializeField] private XRGrabInteractable interactable;

    private MotionHandle rotationTween;
    private Vector3 currentRotation;

    void Start()
    {
        currentRotation = transform.localEulerAngles;

        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnGrab);
            interactable.selectExited.AddListener(OnRelease);
        }

        StartSpin();
    }

    void StartSpin()
    {
    
        rotationTween = LMotion.Create(currentRotation, currentRotation + new Vector3(0, 360, 0), rotationDuration)
            .WithEase(Ease.Linear)
            .WithLoops(-1, LoopType.Restart)
            .BindToLocalEulerAngles(transform);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        if (args.interactorObject is XRSocketInteractor) return;

        if (rotationTween.IsActive()) rotationTween.Cancel();
    }

    void OnRelease(SelectExitEventArgs args)
    {
        if (args.interactorObject is XRSocketInteractor) return;

        currentRotation = transform.localEulerAngles;
        StartSpin();
    }
}