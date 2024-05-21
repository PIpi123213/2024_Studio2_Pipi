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
        // 获取绑定到轨道上的 GameObject
        PlayableDirector director = go.GetComponent<PlayableDirector>();
        GameObject dialogueBox = director.GetGenericBinding(this) as GameObject;

        // 创建并返回 Mixer
        var playable = ScriptPlayable<DialogueMixerBehaviour>.Create(graph, inputCount);

        // 设置每个 TimelineClip 的 dialogueBox 属性
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
