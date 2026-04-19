using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/OrganDefinitionEventChannel")]
public class OrganDefinitionEventChannelSO : ScriptableObject
{
    public Action<string, string> OnEventRaised;

    public void RaiseEvent(string organName, string organDescription)
    {
        OnEventRaised?.Invoke(organName, organDescription);
    }
}
