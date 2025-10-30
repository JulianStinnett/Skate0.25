using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAudio : MonoBehaviour
{
    // Singleton instance so any script can easily play sounds
    public static SimpleAudio Instance { get; private set; }

    public AudioSource jumpSource;  // audio source for jump sound
    public AudioSource crashSource; // audio source for crash sound

    void Awake()
    {
        // Ensure only one SimpleAudio exists across scenes
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // keep this object when loading new scenes
    }

    // Play jump sound if audio source and clip are assigned
    public void PlayJump()
    {
        if (jumpSource && jumpSource.clip)
            jumpSource.Play();
    }

    // Play crash sound if audio source and clip are assigned
    public void PlayCrash()
    {
        if (crashSource && crashSource.clip)
            crashSource.Play();
    }
}