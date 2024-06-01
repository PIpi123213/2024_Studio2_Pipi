using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Timeline1 : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayableDirector playableDirector1; // Reference to the PlayableDirector
    private bool isplayed1 = false;
 
    public PlayableDirector playableDirector2;
    private bool isplayed2 = false;
    void Start()
    {
        if (playableDirector1 != null)
        {
            // 订阅stopped事件
            playableDirector1.stopped += OnPlayableDirectorStopped;
           
        }
       
    }




    void Update()
    {
        // Check the custom condition
        if (Uicontroller.isStart&&!isplayed1)
        {
            PlayTimeline(playableDirector1);
            isplayed1=true;
            //GameManager.instance.gameMode = GameManager.GameMode.CGMoment;
        }
        if (Uicontroller.isStartGame && !isplayed2)
        {
            PlayTimeline(playableDirector2);
            isplayed2 = true;
        }


      


    }

   

    private void PlayTimeline(PlayableDirector _playableDirector)
    {
        // Play the timeline
        if (_playableDirector != null)
        {
            _playableDirector.Play();
            GameManager.instance.gameMode = GameManager.GameMode.CGMoment;
        }
    }
    private void OnPlayableDirectorStopped(PlayableDirector director)
    {
        Debug.Log("PlayableDirector stopped event triggered.");
        if (director == playableDirector1)
        {
            //Uicontroller.isStart = true
            Uicontroller.isStartGame = true;
            Debug.Log("Timeline1 has ended.");
            GameManager.instance.gameMode = GameManager.GameMode.GamePlay;
           
        }
    }

    void OnDestroy()
    {
        if (playableDirector1 != null)
        {
            // 取消订阅stopped事件，以避免内存泄漏
            playableDirector1.stopped -= OnPlayableDirectorStopped;
        }
    }










}
