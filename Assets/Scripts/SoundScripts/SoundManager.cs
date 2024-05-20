using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] gameMusic;
    void Start()
    {
        if(DataManager.instance.musicNum == 0)
        {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = gameMusic[0];
        audioSource.Play();
        SceneManager.sceneLoaded += OnSceneLoaded;
        DontDestroyOnLoad(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int sceneIndex = scene.buildIndex;
        if (sceneIndex < gameMusic.Length && gameMusic[sceneIndex] != null)
        {
            audioSource.clip = gameMusic[sceneIndex];
            audioSource.Play();
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
