using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip[] clips;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClipOneShot(int index)
    {
        audioSource.PlayOneShot(clips[index], 1.0f);
    }
}
