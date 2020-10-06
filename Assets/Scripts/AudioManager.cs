using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance = null;

    AudioSource _audSource = null;

    private void Awake()
    {
        #region Singleton Pattern (Simple)
        if(Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);

            _audSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion
    }

    public void PlaySong(AudioClip clip)
    {
        _audSource.clip = clip;
        _audSource.Play();
    }
}