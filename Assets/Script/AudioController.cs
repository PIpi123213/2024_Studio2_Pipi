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
        // 播放两段背景音乐，并设置循环播放
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
           


        }

        if ((GameManager.instance.scenename == "2"|| GameManager.instance.scenename == "2.1"|| GameManager.instance.scenename == "2.2"||GameManager.instance.scenename == "2.3") && !bool2)
        {
            
            bool2 = true;
            musicTracks[1].Play();


        }
        else if((GameManager.instance.scenename != "2" && GameManager.instance.scenename != "2.1" && GameManager.instance.scenename != "2.2" && GameManager.instance.scenename!= "2.3"))
        {
            musicTracks[1].Stop();
            bool2 = false;


        }




        if (GameManager.instance.scenename == "2.3" )
        {
           
            musicTracks[0].Stop();
            bool1 = false;


        }
        else if(GameManager.instance.scenename != "2.3" && !bool1)
        {
            Debug.Log("play");
            foreach (AudioSource track in musicTracks)
            {
                track.Stop();
            }
            bool1 = true;
            musicTracks[0].Play();




        }

    }


}
