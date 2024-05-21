using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class DialogueClip : PlayableAsset
{
    public DialogueBehavior template = new DialogueBehavior();
    public GameObject dialogueBox;
    
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<DialogueBehavior>.Create(graph, template);




        DialogueBehavior dialogueBehaviour = playable.GetBehaviour();
        //Debug.Log(dialogueBox);
        if (dialogueBehaviour != null && dialogueBox != null)
        {
            
            dialogueBehaviour.Initialize(dialogueBox);
        }


        return playable;
    }

    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
