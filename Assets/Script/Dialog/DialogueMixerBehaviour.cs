using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DialogueMixerBehaviour : PlayableBehaviour
{
    public GameObject dialogueBox;

    // This method can be used to pass the dialogueBox to the DialogueBehavior
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        if (dialogueBox != null)
        {
            for (int i = 0; i < playable.GetInputCount(); i++)
            {
                var inputPlayable = (ScriptPlayable<DialogueBehavior>)playable.GetInput(i);
                var inputBehavior = inputPlayable.GetBehaviour();

                if (inputBehavior != null)
                {
                    inputBehavior.Initialize(dialogueBox);
                }
            }
        }
    }
}
