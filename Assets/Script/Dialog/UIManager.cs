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

    private bool isScrolling = false;
    public float textSpeed;


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
       // _dialogueLineText.text = _line;

        ToggleDialogueBox(_dialogueBox, true);
        StartCoroutine(ScrollingText(_dialogueLineText, _line));
    }
    public void SetupDialogue_noScrolling(GameObject _dialogueBox, TextMeshProUGUI _characterNameText, TextMeshProUGUI _dialogueLineText, string _name, string _line)
    {
        _characterNameText.text = _name;
         _dialogueLineText.text = _line;

        ToggleDialogueBox(_dialogueBox, true);
        //StartCoroutine(ScrollingText(_dialogueLineText, _line));
    }


    private IEnumerator ScrollingText(TextMeshProUGUI dialogueLineText, string line)
    {
        isScrolling = true;
        dialogueLineText.text = "";
        int index = 0;
        while (index < line.Length)
        {
            if (line[index] == '<')
            {
                // ��鸻�ı���ǩ
                int closeIndex = line.IndexOf('>', index);
                if (closeIndex != -1)
                {
                    // ��������ĸ��ı���ǩ
                    dialogueLineText.text += line.Substring(index, closeIndex - index + 1);
                    index = closeIndex + 1;
                }
                else
                {
                    // ���û���ҵ��պϱ�ǩ��ֱ�����ʣ���ַ�
                    dialogueLineText.text += line[index];
                    index++;
                }
            }
            else
            {
                dialogueLineText.text += line[index];
                index++;
                yield return new WaitForSeconds(textSpeed);
            }
        }

        isScrolling = false;


    }



}
