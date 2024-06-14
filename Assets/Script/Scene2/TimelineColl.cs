using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineColl : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayableDirector playableDirector1; // Reference to the PlayableDirector
    private bool isplayed1 = false;// Start is called before the first frame update

    private bool play1Schel = false;
    public string TimelineID;
    public int count;
    
    void Start()
    {
        if (!Timelinetrigger.Instance.Timelines.ContainsKey(TimelineID))
        {
            Timelinetrigger.Instance.Timelines.Add(TimelineID, count);
            Debug.Log("Add");
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (!isplayed1 && play1Schel && Timelinetrigger.Instance.CanPlayTimeline(TimelineID))
        {
            
            PlayTimeline(playableDirector1);
            isplayed1 = true;
            Timelinetrigger.Instance.DecrementPlayCount(TimelineID);

        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")||other.CompareTag("Player2"))
        {
            Debug.Log("play");
            play1Schel = true;

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

}
