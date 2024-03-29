﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChange : MonoBehaviour
{
    private AudioSource audioSrc;

    private float musicVol = 1f;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    void Update()
    {
        audioSrc.volume = musicVol;
    }

    public void SetVolume(float vol)
    {
        musicVol = vol;
    }
    
}
