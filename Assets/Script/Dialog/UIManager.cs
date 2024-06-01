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
        // 如果实例已经存在，则销毁新的实例
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
        // 将当前实例设置为静态实例


        // 确保控制器对象在加载新场景时不被销毁
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
                // 检查富文本标签
                int closeIndex = line.IndexOf('>', index);
                if (closeIndex != -1)
                {
                    // 添加完整的富文本标签
                    dialogueLineText.text += line.Substring(index, closeIndex - index + 1);
                    index = closeIndex + 1;
                }
                else
                {
                    // 如果没有找到闭合标签，直接添加剩余字符
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
