using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Timelinescene11 : MonoBehaviour
{
    // Start is called before the first frame update

    public PlayableDirector playableDirector1; // Reference to the PlayableDirector
    private bool isplayed1 = false;
    public static bool play2schel = false;
    public PlayableDirector playableDirector2;
    private bool isplayed2 = false;
    private int isplayed = 0;
    public GameObject Line;
    public static bool isGameStart = false;
    public PlayableDirector playableDirector3;
    private bool isplayed3 = false;
    public static bool isLose = false;

    public static int isWin_scene1 = 0;


    public GameObject playerCanvas;

    public PlayableDirector player1Timeline;
    public static bool player1win = false;
    private bool isplayer1played = false;



    public PlayableDirector player2Timeline;
    public static bool player2win = false;
    private bool isplayer2played = false;
    public static int isready = 0;



    public GameObject player2;
    public GameObject player1;
    void Start()
    {
        if (playableDirector1 != null)
        {
            // 订阅stopped事件
            playableDirector1.stopped += OnPlayableDirectorStopped;
            player1Timeline.stopped += OnPlayableDirectorStopped;
            player2Timeline.stopped += OnPlayableDirectorStopped;

        }
        Line.SetActive(false);

        isWin_scene1 = 0;
        play2schel = false;
        isGameStart = false;
        player1win = false;
        player2win = false;
        isLose = false;
        isready = 0;
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
        if (play2schel && !isplayed2 && isplayed ==2)
        {
           
            PlayTimeline(playableDirector2);
            isplayed2 = true;
            GameManager.instance.gameMode = GameManager.GameMode.CGMoment;


        }

        if (GameManager.instance.gameMode == GameManager.GameMode.CGMoment)
        {
            playerCanvas.SetActive(false);
        }
        else
        {
            playerCanvas.SetActive(true);
        }

        if (player1win && !isplayer1played)
        {
            PlayTimeline(player1Timeline);
            isplayer1played = true;
        }
        if (player2win && !isplayer2played)
        {
            Line.SetActive(false);
            PlayTimeline(player2Timeline);
            isplayer2played = true;
            player2.SetActive(true);
        }
        if (isLose && !isplayed3)
        {
           
            PlayTimeline(playableDirector3);
            isplayed3 = true;
            
        }

        if(GameManager.instance.gameMode == GameManager.GameMode.DialogueMoment && isLose && isready == 2)
        {



            GameManager.instance.ResumeTimeline();
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
       
        if (director == playableDirector1)
        {
            //Uicontroller.isStart = true
            //play2schel = true;
            isGameStart = true;
            Line.SetActive(true);
            GameManager.instance.gameMode = GameManager.GameMode.GamePlay;

        }
        if (director == player1Timeline)
        {
            Debug.Log("PlayableDirector stopped event triggered.");
            Destroy(player1);
            isplayed++;
        }
        if (director == player2Timeline)
        {
            Debug.Log("PlayableDirector stopped event triggered.");
            isplayed++;

        }
    }
    void OnDestroy()
    {
        if (playableDirector1 != null)
        {
            // 取消订阅stopped事件，以避免内存泄漏
            playableDirector1.stopped -= OnPlayableDirectorStopped;
            player1Timeline.stopped -= OnPlayableDirectorStopped;
                 player2Timeline.stopped -= OnPlayableDirectorStopped;
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
