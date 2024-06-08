using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerScene3 : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 initialPosition;
    public static int isReady = 0;
    private void Awake()
    {
        SaveManager.Instance.initialPosition = initialPosition;
        Vector3 respawnPosition = SaveManager.Instance.LoadNearestCheckpoint();
        transform.position = respawnPosition;
    }


    void Start()
    {
        isReady = 0;


    }

    // Update is called once per frame
    void Update()
    {
        if (TimelineScene3.isLose)
        {
          if(isReady == 2)
            {
                GameManager.instance.ResumeTimeline();
                isReady = 0;
            }


        }

    }

    public void SwitchToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}
