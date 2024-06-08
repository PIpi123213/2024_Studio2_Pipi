using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class policeDialogue : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject dialague;
    public GameObject find;
    private findScene3 find3;
    void Start()
    {
        Transform parentTransform = transform.parent;
        Transform findTransform = parentTransform.Find("find");

        find = findTransform.gameObject;
        find3 = find.GetComponent<findScene3>();
        Transform dialogueTransform = transform.Find("Dialogue box");
        dialague = dialogueTransform.gameObject;

        dialague.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (find3.isFind)
        {



            dialague.SetActive(true);
        }
        else
        {

            dialague.SetActive(false);
        }
    }
}
