using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource[] musicTracks;
    private bool bool1;
    private bool bool2;
    void Start()
    {
        // �������α������֣�������ѭ������
        foreach (AudioSource track in musicTracks)
        {
            track.loop = true;
            //track.Play();
        }
    }

    private void Update()
    {
        if (GameManager.instance.scenename == "0" && !bool1)
        {
            Debug.Log("play");
            foreach (AudioSource track in musicTracks)
            {
                track.Stop();
            }
            bool1 = true;
            musicTracks[0].Play();


        }

        if (GameManager.instance.scenename == "1" && !bool2)
        {
            foreach (AudioSource track in musicTracks)
            {
                track.Stop();
            }
            bool2 = true;
            musicTracks[1].Play();


        }



    }


}
