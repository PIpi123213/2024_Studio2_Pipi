using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
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
    }


    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        isClipPlayed=false;
        if (pauseScheduled)
        {
            pauseScheduled=false;
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
