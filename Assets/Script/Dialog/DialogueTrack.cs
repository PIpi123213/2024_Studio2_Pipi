using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


[TrackClipType(typeof(DialogueClip))]
[TrackColor(200/255f,200/255f,100/255f)]
[TrackBindingType(typeof(GameObject))]
public class DialogueTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        // ��ȡ�󶨵�����ϵ� GameObject
        PlayableDirector director = go.GetComponent<PlayableDirector>();
        GameObject dialogueBox = director.GetGenericBinding(this) as GameObject;

        // ���������� Mixer
        var playable = ScriptPlayable<DialogueMixerBehaviour>.Create(graph, inputCount);

        // ����ÿ�� TimelineClip �� dialogueBox ����
        foreach (var clip in GetClips())
        {
            var dialogueClip = clip.asset as DialogueClip;
            if (dialogueClip != null)
            {
                dialogueClip.dialogueBox = dialogueBox;
            }
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
