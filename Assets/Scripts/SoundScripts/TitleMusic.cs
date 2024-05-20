using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMusic : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip title;

     void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = title;
        audioSource.Play();
    }
}
