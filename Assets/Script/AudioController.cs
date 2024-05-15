using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource[] musicTracks;

    void Start()
    {
        // 播放两段背景音乐，并设置循环播放
        foreach (AudioSource track in musicTracks)
        {
            track.loop = true;
            track.Play();
        }
    }
}
