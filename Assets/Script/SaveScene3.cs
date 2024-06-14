using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScene3 : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 initialPosition;
    
    private void Awake()
    {
        SaveManager.Instance.initialPosition = initialPosition;
        Vector3 respawnPosition = SaveManager.Instance.LoadNearestCheckpoint();
        transform.position = respawnPosition;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
