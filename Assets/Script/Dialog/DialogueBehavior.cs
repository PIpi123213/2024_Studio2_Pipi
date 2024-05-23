using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[System.Serializable]
public class DialogueBehavior : PlayableBehaviour
{
    // Start is called before the first frame update
    private PlayableDirector playableDirector;
    public string characterName;
    [TextArea(8,1)]public string dialogueLine;
    //public int dialogueSize;

    private bool isClipPlayed;//是否播放结束
    public bool requirePause;//是否需要按下空格
    private bool pauseScheduled;
    public bool ffScheduled = true;

    private GameObject dialogueBox;
    private TextMeshProUGUI characterNameText;
    private TextMeshProUGUI dialogueLineText;
    private GameObject spacebar;
    public void Initialize(GameObject _dialogueBox)
    {
        dialogueBox = _dialogueBox;
        characterNameText = dialogueBox.transform.Find("CharacterNameText").GetComponent<TextMeshProUGUI>();
        dialogueLineText = dialogueBox.transform.Find("DialogueLineText").GetComponent<TextMeshProUGUI>();
        spacebar = dialogueBox.transform.Find("Spacebar").gameObject;

    }


    public override void OnPlayableCreate(Playable playable)
    {
        playableDirector = playable.GetGraph().GetResolver() as PlayableDirector;

    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        if(isClipPlayed==false && info.weight > 0)
        {
            UIManager.instance.SetupDialogue(dialogueBox, characterNameText, dialogueLineText,characterName, dialogueLine);
            if (requirePause)
            {
                pauseScheduled = true;
            }
            isClipPlayed = true;
            





        }

        if(isClipPlayed && info.weight > 0 && ffScheduled == true)
        {
            

            double currentTime = playableDirector.time;
            double closestTime = double.MaxValue;

            foreach (var output in playableDirector.playableAsset.outputs)
            {
                var track = output.sourceObject as TrackAsset;
                if (track != null)
                {
                    foreach (var clip in track.GetClips())

                    {

                        if (clip.start > currentTime && clip.start < closestTime)
                        {
                            closestTime = clip.start;
                        }
                        if (clip.end > currentTime && clip.end < closestTime)
                        {
                            closestTime = clip.end;
                        }



                    }
                }
            }

            if (closestTime != double.MaxValue)
            {
                Debug.Log("isplay2");
                GameManager.instance.SetClosestClipEndTime(playableDirector, closestTime);
            }
        }
            

        
        //Debug.Log("isplay1");

    }
    

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        //Debug.Log("ispause");
        isClipPlayed=false;
        
        double currentTime = playableDirector.time;
        double closestTime = double.MaxValue;

        foreach (var output in playableDirector.playableAsset.outputs)
        {
            var track = output.sourceObject as TrackAsset;
            if (track != null)
            {
                foreach (var clip in track.GetClips())
                {
                    if (clip.start > currentTime && clip.start < closestTime)
                    {
                        closestTime = clip.start;
                    }
                }
            }
        }

        if (closestTime != double.MaxValue)
        {
            Debug.Log("Next clip found");
            GameManager.instance.SetClosestClipEndTime(playableDirector, closestTime);
        }
        if (pauseScheduled)
        {
            
            pauseScheduled =false;
            GameManager.instance.PauseTimeline(playableDirector, spacebar, dialogueBox);
        }
        else
        {
            
            UIManager.instance.ToggleDialogueBox(dialogueBox, false);
        }
    }

   


    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




}
