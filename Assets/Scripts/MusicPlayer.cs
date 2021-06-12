using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    AudioSource audioSource;


    void Awake()
    {
        SetUpSingleton();
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }


    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    private void SetUpSingleton()
    {
        int numberOfGameSessions = FindObjectsOfType(GetType()).Length;

        if (numberOfGameSessions > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
