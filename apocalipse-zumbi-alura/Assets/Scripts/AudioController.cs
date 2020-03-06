using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource _audioSource;
    public static AudioSource instancia;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        instancia = _audioSource;
    }
}
