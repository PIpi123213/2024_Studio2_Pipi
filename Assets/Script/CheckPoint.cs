using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public string checkpointID;
    private bool player1=false;
    private bool player2=false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("save");
            player1 = true; 
           
        }
        if (other.CompareTag("Player2"))
        {
            Debug.Log("save");
            player2 = true;
           
        }
    }
    private void Update()
    {
        if (player1 && player2)
        {
            Debug.Log("save2");
            SaveManager.Instance.SaveCheckpoint(checkpointID, transform.position);
        }
        if (GameManager.instance.scenename == "2" )
        {
            if (player1)
            {
                SaveManager.Instance.SaveCheckpoint(checkpointID, transform.position);
            }


        }




    }

}
