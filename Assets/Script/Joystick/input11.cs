using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input11 : MonoBehaviour
{
    private Vector2 leftStickInput;
    private Vector2 prevLeftStickInput;
    public float angleThreshold = 5f;
    void Update()
    {
        leftStickInput = new Vector2(Input.GetAxis("LeftStickX"), Input.GetAxis("LeftStickY"));

        // 获取左摇杆的旋转方向和速度
        float leftStickRotation = GetStickRotation(leftStickInput, prevLeftStickInput);
        float leftStickSpeed = GetStickSpeed(leftStickInput);

        // 打印左摇杆信息
        if (Mathf.Abs(leftStickRotation) >= angleThreshold)
        {
            // 打印左摇杆信息
            if (leftStickRotation > 0f)
            {
                Debug.Log("Left Stick: Clockwise Rotation, Speed: " + leftStickSpeed);
            }
            else if (leftStickRotation < 0f)
            {
                Debug.Log("Left Stick: Counter-clockwise Rotation, Speed: " + leftStickSpeed);
            }
            else
            {
                Debug.Log("Left Stick: Not rotating");
            }
        }

        prevLeftStickInput = leftStickInput;
    }

    float GetStickRotation(Vector2 currentInput, Vector2 prevInput)
    {
        float angle = Vector2.SignedAngle(prevInput, currentInput);
        return angle;
    }

    float GetStickSpeed(Vector2 stickInput)
    {
        return stickInput.magnitude;
    }
}
