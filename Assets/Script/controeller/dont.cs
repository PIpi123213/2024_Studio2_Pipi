using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dont : MonoBehaviour
{
    // Start is called before the first frame update
    private static dont instance;

    void Awake() {
        // ���ʵ���Ѿ����ڣ��������µ�ʵ��
        if (instance != null) {
            Destroy(gameObject);
            return;
        }

        // ����ǰʵ������Ϊ��̬ʵ��
        instance = this;

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
}
