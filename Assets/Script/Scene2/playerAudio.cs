using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    public List<AudioClip> audioClips;
    public AudioClip HitaudioClip;
    private bool isPlaying = false;

    public float minVolume = 0.5f;
    public float maxVolume = 1.0f;
    public float changeSpeed = 0.5f;
    private float targetVolume;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (PlayerController.speed>0.1f )
        {
            Debug.Log("ROW");
            playRandomAudio();
            SmoothVolumeChange();
        }
        else
        {
            stopAudio();



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

    public void playRandomAudio()
    {
        if (!isPlaying)
        {
            
            int randomIndex = Random.Range(0, audioClips.Count);
            audioSource.clip = audioClips[randomIndex];
            audioSource.Play();
            isPlaying = true;
            
        }
    }

    private void SmoothVolumeChange()
    {
        audioSource.volume = Mathf.MoveTowards(audioSource.volume, targetVolume, changeSpeed * Time.deltaTime);
        if (audioSource.volume == targetVolume)
        {
            targetVolume = Random.Range(minVolume, maxVolume);
        }
    }

    public void playhit(float volume)
    {
        audioSource.clip = HitaudioClip;
        audioSource.volume = volume;
        audioSource.PlayOneShot(HitaudioClip);




    }
}
