using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

[RequireComponent(typeof(XRGrabInteractable))]
public class OrganController : MonoBehaviour
{
    [Header("Organ Definition")]
    [SerializeField] private OrganDefinitionEventChannelSO stringEventChannelSO;
    [SerializeField] private OrganSO organSO;

    [Header("Organ Quiz")]
    [SerializeField] private QuizEventChannelSO quizSO;
    [SerializeField] private OrganQuizSO organQuizSO;

    private XRGrabInteractable interactable;

    private void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
    }

    private void Start()
    {
        interactable.selectEntered.AddListener(OnGrab);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        if (args.interactorObject is XRSocketInteractor) return;

        stringEventChannelSO.RaiseEvent(organSO.Name, organSO.Description);

        quizSO.RaiseEvent(organQuizSO.GetQuizData());
    }
}
