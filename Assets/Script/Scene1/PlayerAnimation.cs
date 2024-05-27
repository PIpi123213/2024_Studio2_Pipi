using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;

    // ��ʼ��
    void Start()
    {
        // ��ȡ Animator ���
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        















    }
    // �����ײ����
    void OnTriggerEnter(Collider other)
    {
        // �����ײ�����Ƿ���Ŀ�꣨���Ը���ʵ�����������
        if (other.CompareTag("DiggingArea"))
        {
            // ���� isDiging ����Ϊ true
            animator.SetBool("isDiging", true);
        }
    }

    // �����ײ�˳�
    void OnTriggerExit(Collider other)
    {
        // �뿪�ھ�����ʱ���� isDiging ������Ϊ false
        if (other.CompareTag("DiggingArea"))
        {
            animator.SetBool("isDiging", false);
        }
    }
}
