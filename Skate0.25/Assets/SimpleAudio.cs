using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAudio : MonoBehaviour
{
    public static SimpleAudio Instance { get; private set; }
    public AudioSource jumpSource;
    public AudioSource crashSource;

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayJump() { if (jumpSource && jumpSource.clip) jumpSource.Play(); }
    public void PlayCrash() { if (crashSource && crashSource.clip) crashSource.Play(); }
}