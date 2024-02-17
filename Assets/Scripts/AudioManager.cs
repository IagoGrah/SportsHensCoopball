using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : PersistentSingletonBehaviour<AudioManager>
{
    AudioSource audioSource;

    [SerializeField] AudioClip goalSound;
    [SerializeField] AudioClip kickSound;

    [SerializeField] float kickSoundMinInterval = 0.15f;
    float lastKickSoundElapsed;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void Update()
    {
        lastKickSoundElapsed += Time.deltaTime;
    }

    public void PlayKickSound()
    {
        if (lastKickSoundElapsed > kickSoundMinInterval)
        {
            audioSource.PlayOneShot(kickSound);
            lastKickSoundElapsed = 0f;
        }
    }

    public void PlayGoalSound()
    {
        audioSource.PlayOneShot(goalSound);
    }
}
