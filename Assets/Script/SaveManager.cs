using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Threading.Tasks;
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
    // 保存存档点位置
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

    // 加载最近的存档点位置
    public Vector3 LoadNearestCheckpoint()
    {
        if (checkpoints.Count > 0)
        {
            // 在字典中查找最后一个存档点的位置
            string lastCheckpointID = new List<string>(checkpoints.Keys)[checkpoints.Count - 1];
            Debug.Log("save Point");
            return checkpoints[lastCheckpointID];
           
        }
        else
        {
            // 如果没有存档点，返回默认的重生位置
            return initialPosition;
        }
    }

    // 重置存档点
    public void ResetCheckpoints()
    {
        Debug.Log("clear");
        checkpoints.Clear();
    }
    public async Task ResetCheckpointsAsync()
    {
        // 模拟一段异步操作
        await Task.Delay(1000); // 假设这是您的异步保存逻辑
        //await Task.Delay(1000); // 假设这是您的异步保存逻辑

        // 重置检查点的实际逻辑
        checkpoints.Clear();
        // 重置检查点的实际逻辑
        // Debug.Log(&quot; Checkpoints Reset Finished & quot;);
    }


}
