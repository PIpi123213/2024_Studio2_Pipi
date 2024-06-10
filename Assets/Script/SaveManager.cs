using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SaveManager Instance { get; private set; }

    private Dictionary<string, Vector3> checkpoints = new Dictionary<string, Vector3>();
    public Vector3 initialPosition;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {

        
    }
    // ����浵��λ��
    public void SaveCheckpoint(string checkpointID, Vector3 position)
    {
        if (!checkpoints.ContainsKey(checkpointID))
        {
            checkpoints.Add(checkpointID, position);
        }
        else
        {
            checkpoints[checkpointID] = position;
        }
    }

    // ��������Ĵ浵��λ��
    public Vector3 LoadNearestCheckpoint()
    {
        if (checkpoints.Count > 0)
        {
            // ���ֵ��в������һ���浵���λ��
            string lastCheckpointID = new List<string>(checkpoints.Keys)[checkpoints.Count - 1];
            Debug.Log("save Point");
            return checkpoints[lastCheckpointID];
           
        }
        else
        {
            // ���û�д浵�㣬����Ĭ�ϵ�����λ��
            return initialPosition;
        }
    }

    // ���ô浵��
    public void ResetCheckpoints()
    {
        checkpoints.Clear();
    }


   
}
