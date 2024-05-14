using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input11 : MonoBehaviour
{
    private Vector2 leftStickInput;
    private Vector2 prevLeftStickInput;


    private Vector2 rightStickInput;
    private Vector2 prevRightStickInput;

    public static float direction;
    public static float speed;

    public static float direction2;
    public static float speed2;

    public float angleThreshold = 5f;
    void Update()
    {
        leftStickInput = new Vector2(Input.GetAxis("LeftStickX"), Input.GetAxis("LeftStickY"));
        rightStickInput = new Vector2(Input.GetAxis("RightStickX"), Input.GetAxis("RightStickY"));


        // 获取左摇杆的旋转方向和速度
        float leftStickRotation = GetStickRotation(leftStickInput, prevLeftStickInput);
        float rightStickRotation = GetStickRotation(rightStickInput, prevRightStickInput);
        float leftStickSpeed = GetStickSpeed(leftStickInput);
        float rightStickSpeed = GetStickSpeed(rightStickInput);
        
        // 打印左摇杆信息
        if (Mathf.Abs(leftStickRotation) >= angleThreshold)
        {
            direction = Mathf.Sign(leftStickRotation);
            speed = Mathf.Abs(leftStickSpeed) * 6.5f;
            // 打印左摇杆信息
            
        }
        else
        {
            direction = 0f;
            speed = 0f;

        }

        

        if (Mathf.Abs(rightStickRotation) >= angleThreshold)
        {
            direction2 = Mathf.Sign(rightStickRotation);
            speed2 = Mathf.Abs(rightStickSpeed);
            // 打印左摇杆信息
            
        }
        else
        {
            direction2 = 0f;
            speed2 = 0f;

        }
       /* Debug.Log("1"+speed);
        Debug.Log("2"+speed2);*/
        prevLeftStickInput = leftStickInput;
        prevRightStickInput = rightStickInput;
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
