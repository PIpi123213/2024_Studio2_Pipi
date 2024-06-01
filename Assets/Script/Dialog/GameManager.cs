using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update private static arduino123 instance;
    public int targetFrameRate = 24;
    public static GameManager instance;
    public static int iswinscene2 = 0;




    public enum GameMode
    {
        GamePlay,
        DialogueMoment,
        CGMoment
    }
    public GameMode gameMode;
    private PlayableDirector currentplayDirector;
    private GameObject currentspacebar;
    private GameObject currentdialoguebox;
    private double closestClipEndTime;
    private arduino123 _arduino123;
    private input11 _input11;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        // 将当前实例设置为静态实例


        // 确保控制器对象在加载新场景时不被销毁
        DontDestroyOnLoad(gameObject);
        gameMode = GameMode.GamePlay;
        //Application.targetFrameRate = 30;
        _arduino123 = GetComponent<arduino123>();
        _input11 = GetComponent<input11>();
    }
    public void PauseTimeline(PlayableDirector _playableDirector, GameObject spacebar,GameObject dialoguebox)
    {
        currentplayDirector = _playableDirector;
        currentspacebar = spacebar;
        currentdialoguebox = dialoguebox;
        gameMode = GameMode.DialogueMoment;
        currentplayDirector.playableGraph.GetRootPlayable(0).SetSpeed(0d);
        UIManager.instance.ToggleSpaceBar(spacebar,true);



    }

    public void ResumeTimeline()
    {
        gameMode=GameMode.GamePlay;
        currentplayDirector.playableGraph.GetRootPlayable(0).SetSpeed(1d);
        UIManager.instance.ToggleSpaceBar(currentspacebar,false);
        UIManager.instance.ToggleDialogueBox(currentdialoguebox,false);
    }

    public void SetClosestClipEndTime(PlayableDirector _playableDirector, double endTime)
    {
        currentplayDirector = _playableDirector;
       
            closestClipEndTime= endTime;
        
        
            
        
    }
    private void JumpToClipEnd()
    {
        if (currentplayDirector == null)
            return;

        if (closestClipEndTime != double.MaxValue)
        {
            currentplayDirector.time = closestClipEndTime - 0.01f;
            currentplayDirector.Evaluate();
            gameMode = GameMode.GamePlay;
            currentplayDirector.playableGraph.GetRootPlayable(0).SetSpeed(1d);
        }
        else
        {
            return;
        }

    }


    void Start()
    {
        QualitySettings.vSyncCount = 0; // 禁用 VSync
        Application.targetFrameRate = targetFrameRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameMode == GameMode.DialogueMoment)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ResumeTimeline();
            }






        }
        if (Input.GetKeyDown(KeyCode.E) && currentplayDirector!=null && gameMode == GameMode.GamePlay )
        {
            JumpToClipEnd();
            
            
        }


        if (iswinscene2 == 2)
        {
            GameWin();

        }



        if(gameMode == GameMode.GamePlay)
        {
            _arduino123.enabled = true;
            _input11.enabled = true;


        }
        else
        {
            _arduino123.enabled = false;
            _input11.enabled = false;


        }










    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        // 在这里处理游戏结束的逻辑，例如重新加载场景或者显示游戏结束画面等




        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameWin()
    {
        Debug.Log("Game Win");
        // 在这里处理游戏结束的逻辑，例如重新加载场景或者显示游戏结束画面等
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }




}
