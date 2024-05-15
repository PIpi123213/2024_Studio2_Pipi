using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPolice : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    public AudioClip audioClip;
    private bool isPlaying = false;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void playAudio()
    {
        if (!isPlaying)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
            isPlaying = true;
        }

    }


    public void stopAudio()
    {
        if (isPlaying)
        {
            audioSource.Stop();
            isPlaying = false;
        }
    }
}
