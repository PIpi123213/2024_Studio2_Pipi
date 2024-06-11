using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimelineScene3 : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayableDirector playableDirector1; // Reference to the PlayableDirector
    private bool isplayed1 = false;
    public static bool play2schel = false;
    public PlayableDirector playableDirector2;
    private bool isplayed2 = false;
    public PlayableDirector playableDirector3;
    private bool isplayed3 = false;


    public static bool isGameStart = false;
   
    public static bool isLose = false;
    public static int isWin = 0;
    void Start()
    {
        if (playableDirector1 != null)
        {
            // 订阅stopped事件
            playableDirector1.stopped += OnPlayableDirectorStopped;
            playableDirector2.stopped += OnPlayableDirectorStopped;

        }
        
        play2schel = false;
        isGameStart = false;
        isLose = false;
        isWin = 0;
    }




    void Update()
    {
        // Check the custom condition
        if (!isplayed1)
        {
            PlayTimeline(playableDirector1);
            isplayed1 = true;
            GameManager.instance.gameMode = GameManager.GameMode.CGMoment;
           
        }
        if (isLose && !isplayed2)
        {
            isGameStart = false;
            PlayTimeline(playableDirector2);
            isplayed2 = true;
            GameManager.instance.gameMode = GameManager.GameMode.CGMoment;


        }
        if (isWin ==2 && !isplayed3)
        {
            PlayTimeline(playableDirector3);
            isplayed3 = true;

            GameManager.instance.gameMode = GameManager.GameMode.CGMoment;
        }
     


    }
    private void PlayTimeline(PlayableDirector _playableDirector)
    {
        // Play the timeline
        if (_playableDirector != null)
        {
            _playableDirector.Play();

            //GameManager.instance.gameMode = GameManager.GameMode.CGMoment;
        }
    }
    private void OnPlayableDirectorStopped(PlayableDirector director)
    {
        Debug.Log("PlayableDirector stopped event triggered.");
        if (director == playableDirector1)
        {
          
         
            GameManager.instance.gameMode = GameManager.GameMode.GamePlay;
            isGameStart = true;

        }
        if (director == playableDirector2)
        {
           
        }

    }
    void OnDestroy()
    {
        if (playableDirector1 != null)
        {
            // 取消订阅stopped事件，以避免内存泄漏
            playableDirector1.stopped -= OnPlayableDirectorStopped;
            playableDirector2.stopped -= OnPlayableDirectorStopped;
        }
    }


    public void SwitchToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Timelinetrigger.Instance.clear();
    }


    public void BackToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }




}
