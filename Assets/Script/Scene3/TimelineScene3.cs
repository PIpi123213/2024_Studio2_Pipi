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

   
    public static bool isGameStart = false;
   

    void Start()
    {
        if (playableDirector1 != null)
        {
            // ����stopped�¼�
            playableDirector1.stopped += OnPlayableDirectorStopped;

        }
       
        play2schel = false;
        isGameStart = false;
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
        if (play2schel && !isplayed2)
        {

            PlayTimeline(playableDirector2);
            isplayed2 = true;
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
            // ȡ������stopped�¼����Ա����ڴ�й©
            playableDirector1.stopped -= OnPlayableDirectorStopped;
        }
    }


    public void SwitchToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}