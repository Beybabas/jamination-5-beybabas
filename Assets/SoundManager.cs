using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    [SerializeField] private AudioSource source;


    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void PlayHitSound(AudioClip clip)
    {
     source.PlayOneShot(clip);   
    }

    public void PlayBombSound(AudioClip clip) => source.PlayOneShot(clip);
}
