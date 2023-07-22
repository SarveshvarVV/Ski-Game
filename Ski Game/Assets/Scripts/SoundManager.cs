using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Tooltip("The component these sound effects will play from.")]
    public AudioSource audioSource;

    [Tooltip("Sound effect/clip.")]
    public AudioClip start, mode, finish, jump, crash, flagCapture, flagMiss;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartSound()
    {
        audioSource.PlayOneShot(start);
    }

    public void ModeSound()
    {
        audioSource.PlayOneShot(mode);
    }

    public void FinishSound()
    {
        audioSource.PlayOneShot(finish);
    }

    public void JumpSound()
    {
        audioSource.PlayOneShot(jump);
    }

    public void CrashSound()
    {
        audioSource.PlayOneShot(crash);
    }

    public void FlagCaptureSound()
    {
        audioSource.PlayOneShot(flagCapture);
    }

    public void FlagMissSound()
    {
        audioSource.PlayOneShot(flagMiss);
    }
}