using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyconSearch : MonoBehaviour
{
    // Start is called before the first frame update

    void Update()
    {
        // 检测所有连接的游戏手柄
        string[] connectedJoysticks = Input.GetJoystickNames();

        if (connectedJoysticks.Length == 0)
        {
            Debug.Log("没有检测到任何手柄连接");
            return;
        }

        // 遍历所有连接的手柄
        for (int i = 0; i < connectedJoysticks.Length; i++)
        {
            string joystickName = connectedJoysticks[i];
            Debug.Log($"检测到Joy-Con连接: {joystickName} (索引: {i + 1})");

            // 可以进一步检测具体输入是否有效
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Joy-Con按钮A被按下，确认连接有效");
            }
            // Switch Joy-Con通常会被识别为以下名称
          
        }
    }
}
