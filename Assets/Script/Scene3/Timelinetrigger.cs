using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timelinetrigger : MonoBehaviour
{
    // Start is called before the first frame update
   

    public static Timelinetrigger Instance;

    public Dictionary<string, int> Timelines  = new Dictionary<string, int>();
    private string currentSceneName;
  
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }

        currentSceneName = SceneManager.GetActiveScene().name;




    }
    public bool CanPlayTimeline(string timelineName)
    {
        if (Timelines.ContainsKey(timelineName) && Timelines[timelineName] > 0)
        {
            Debug.Log("need");
            return true;
        }
        return false;
    }

     public void DecrementPlayCount(string timelineName)
    {
        if (Timelines.ContainsKey(timelineName) && Timelines[timelineName] > 0)
        {
            Debug.Log("played");
            Timelines[timelineName]--;
        }
    }

    public int GetPlayCount(string timelineName)
    {
        if (Timelines.ContainsKey(timelineName))
        {
            return Timelines[timelineName];
        }
        return 0;
    }

    void Start()
    {
       /* if (GameManager.instance.scenename != "3")
        {
            SaveManager.Instance.ResetCheckpoints();
            Destroy(gameObject);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        /*  if (GameManager.instance.scenename != "3")
          {
              SaveManager.Instance.ResetCheckpoints();
              Destroy(gameObject);

          }*/


        string newSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName != newSceneName)
        {
            Debug.Log("Scene changed from " + currentSceneName + " to " + newSceneName);

            // ������ִ�г����л�����߼�
            // ��������ĳЩ���������ĳЩ״̬��
            //Timelines.Clear();
            // ���µ�ǰ����������
            //Destroy(gameObject);
            currentSceneName = newSceneName;
        }
    }
   public void clear()
    {
        Debug.Log("clean");
        Timelines.Clear();
    }
}
