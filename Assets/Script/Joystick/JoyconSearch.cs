using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyconSearch : MonoBehaviour
{
    // Start is called before the first frame update

    void Update()
    {
        // ����������ӵ���Ϸ�ֱ�
        string[] connectedJoysticks = Input.GetJoystickNames();

        if (connectedJoysticks.Length == 0)
        {
            Debug.Log("û�м�⵽�κ��ֱ�����");
            return;
        }

        // �����������ӵ��ֱ�
        for (int i = 0; i < connectedJoysticks.Length; i++)
        {
            string joystickName = connectedJoysticks[i];
            Debug.Log($"��⵽Joy-Con����: {joystickName} (����: {i + 1})");

            // ���Խ�һ�������������Ƿ���Ч
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Joy-Con��ťA�����£�ȷ��������Ч");
            }
            // Switch Joy-Conͨ���ᱻʶ��Ϊ��������
          
        }
    }
}
