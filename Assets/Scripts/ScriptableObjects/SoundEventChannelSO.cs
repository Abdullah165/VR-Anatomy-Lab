using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/SoundEventChannelSO")]
public class SoundEventChannelSO : ScriptableObject
{
    public Action<AudioClip> OnEventRaised;

    public void RaiseEvent(AudioClip clip)
    {
        OnEventRaised?.Invoke(clip);
    }
}
