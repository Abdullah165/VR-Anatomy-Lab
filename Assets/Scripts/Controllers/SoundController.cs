using System;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private SoundEventChannelSO cheerSoundEventChannelSO;
    [SerializeField] private SoundEventChannelSO disappointmentSoundEventChannelSO;


    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        cheerSoundEventChannelSO.OnEventRaised += PlayCheerSound;
        disappointmentSoundEventChannelSO.OnEventRaised += PlayDisappointmentSound;
    }


    private void OnDisable()
    {
        cheerSoundEventChannelSO.OnEventRaised -= PlayCheerSound;
        disappointmentSoundEventChannelSO.OnEventRaised -= PlayDisappointmentSound;
    }
    private void PlayCheerSound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
    private void PlayDisappointmentSound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
