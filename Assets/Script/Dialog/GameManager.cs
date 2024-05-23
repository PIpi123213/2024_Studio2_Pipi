using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update private static arduino123 instance;

    public static GameManager instance;
    public enum GameMode
    {
        GamePlay,
        DialogueMoment
    }
    public GameMode gameMode;
    private PlayableDirector currentplayDirector;
    private GameObject currentspacebar;
    private GameObject currentdialoguebox;
    private double closestClipEndTime;
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
        Application.targetFrameRate = 30;
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




    }
}
