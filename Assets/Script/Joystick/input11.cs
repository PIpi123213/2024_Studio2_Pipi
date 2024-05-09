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

        // ��ȡ��ҡ�˵���ת������ٶ�
        float leftStickRotation = GetStickRotation(leftStickInput, prevLeftStickInput);
        float leftStickSpeed = GetStickSpeed(leftStickInput);

        // ��ӡ��ҡ����Ϣ
        if (Mathf.Abs(leftStickRotation) >= angleThreshold)
        {
            // ��ӡ��ҡ����Ϣ
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
