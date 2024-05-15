using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource[] musicTracks;

    void Start()
    {
        // �������α������֣�������ѭ������
        foreach (AudioSource track in musicTracks)
        {
            track.loop = true;
            track.Play();
        }
    }
}
