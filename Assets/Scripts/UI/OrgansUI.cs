using System;
using TMPro;
using UnityEngine;

public class OrgansUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private GameObject OrganPanel;

    [SerializeField] private OrganDefinitionEventChannelSO heartEventChannelSO;
    [SerializeField] private OrganDefinitionEventChannelSO brainEventChannelSO;
    [SerializeField] private OrganDefinitionEventChannelSO lungEventChannelSO;
    [SerializeField] private OrganDefinitionEventChannelSO stomachEventChannelSO;

    private void OnEnable()
    {
        heartEventChannelSO.OnEventRaised += UpdateUI;
        brainEventChannelSO.OnEventRaised += UpdateUI;
        lungEventChannelSO.OnEventRaised += UpdateUI;
        stomachEventChannelSO.OnEventRaised += UpdateUI;
    }

    private void OnDisable()
    {
        heartEventChannelSO.OnEventRaised -= UpdateUI;
        brainEventChannelSO.OnEventRaised -= UpdateUI;
        lungEventChannelSO.OnEventRaised -= UpdateUI;
        stomachEventChannelSO.OnEventRaised -= UpdateUI;
    }

    private void Start()
    {
        OrganPanel.SetActive(false);
    }

    private void UpdateUI(string arg1, string arg2)
    {
        OrganPanel.SetActive(true);
        name.text = arg1;
        description.text = arg2;
    }

}
