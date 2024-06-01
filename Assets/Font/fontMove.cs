using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fontMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float frequency = 1.0f; // Ƶ�ʣ������Ŵ���С���ٶ�
    public float minScaleMultiplier = 0.5f; // ��С���ű���
    public float maxScaleMultiplier = 1.5f; // ������ű���

    private bool scalingUp = true; // �Ƿ��ڷŴ�
    private float timer = 0.0f;
    private Vector3 originalScale; // ��ʼ����ֵ

    private void Start()
    {
        // ��¼��ʼ����ֵ
        originalScale = transform.localScale;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1.0f / frequency)
        {
            timer = 0.0f;

            // �л�����״̬
            if (scalingUp)
            {
                transform.localScale = originalScale * maxScaleMultiplier;
            }
            else
            {
                transform.localScale = originalScale * minScaleMultiplier;
            }

            scalingUp = !scalingUp;
        }
    }

}
