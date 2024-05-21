using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

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
        // ����ǰʵ������Ϊ��̬ʵ��


        // ȷ�������������ڼ����³���ʱ��������
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
    }
}
