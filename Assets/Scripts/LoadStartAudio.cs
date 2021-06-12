using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadStartAudio : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioClip audioLoading;
    void Start()
    {
        AudioSource.PlayClipAtPoint(audioLoading, Camera.main.transform.position);
    }

}
