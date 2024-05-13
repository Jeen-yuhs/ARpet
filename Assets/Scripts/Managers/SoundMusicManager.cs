using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMusicManager : MonoBehaviour
{
    public static SoundMusicManager instance;
    public AudioSource[] audioSources;
    public AudioClip[] music, sfx;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one SoundMusicManager in the Scene");
    }
}
