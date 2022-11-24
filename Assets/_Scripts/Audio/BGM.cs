using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    private AudioSource _backgroundMusic;

    private static BGM instance = null;
    public static BGM Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        _backgroundMusic = GetComponent<AudioSource>();

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    internal void PlayBGClip(AudioClip clip)
    {
        _backgroundMusic.clip = clip;
        _backgroundMusic.Play();

    }

}
