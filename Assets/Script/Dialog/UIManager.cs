using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIManager instance;

   /* public GameObject dialogueBox;
    public TextMeshProUGUI characterNameText;
    public TextMeshProUGUI dialogueLineText;
    public GameObject spacebar;*/




    void Awake()
    {
        // ���ʵ���Ѿ����ڣ��������µ�ʵ��
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        // ����ǰʵ������Ϊ��̬ʵ��


        // ȷ�������������ڼ����³���ʱ��������
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /* public void ToggleDialogueBox(bool _isActive)
     {
         dialogueBox.gameObject.SetActive(_isActive);

     }

     public void ToggleSpaceBar(bool _isActive)
     {
         spacebar.gameObject.SetActive(_isActive);

     }

     public void SetupDialogue(string _name,string _line)
     {
         characterNameText.text = _name;
         dialogueLineText.text = _line;

         ToggleDialogueBox(true);
     }*/

    public void ToggleDialogueBox(GameObject _dialogueBox, bool _isActive)
    {
        _dialogueBox.SetActive(_isActive);
    }

    public void ToggleSpaceBar(GameObject _spacebar, bool _isActive)
    {
        _spacebar.SetActive(_isActive);
    }

    public void SetupDialogue(GameObject _dialogueBox, TextMeshProUGUI _characterNameText, TextMeshProUGUI _dialogueLineText, string _name, string _line)
    {
        _characterNameText.text = _name;
        _dialogueLineText.text = _line;

        ToggleDialogueBox(_dialogueBox, true);
    }




}
