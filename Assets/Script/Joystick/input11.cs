
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
    private List<Joycon> joycons;

    //public JoyconDemo Left;
    //public JoyconDemo Right;
    //public float deadZone = 0.1f;

    public float angleThreshold = 5f;
    private float leftStickRotation;
    private float rightStickRotation;
    private float leftStickSpeed ;
    private float rightStickSpeed;
    void Start()
    {
      
        joycons = JoyconManager.Instance.j;
       
    }

    void Update()
    {
        // leftStickInput = new Vector2(Input.GetAxis("LeftStickX"), Input.GetAxis("LeftStickY"));
        //rightStickInput = new Vector2(Input.GetAxis("RightStickX"), Input.GetAxis("RightStickY"));
        if (JoyconManager.Instance.isJoycon)
        {
            if (joycons[0].isLeft)
            {
                leftStickInput = new Vector2(joycons[0].stick[0], joycons[0].stick[1]);
                rightStickInput = new Vector2(joycons[1].stick[0], joycons[1].stick[1]);
            }
            else
            {
                rightStickInput = new Vector2(joycons[0].stick[0], joycons[0].stick[1]);
                leftStickInput = new Vector2(joycons[1].stick[0], joycons[1].stick[1]);
            }
            leftStickRotation = -GetStickRotation(leftStickInput, prevLeftStickInput);
            rightStickRotation = -GetStickRotation(rightStickInput, prevRightStickInput);
            leftStickSpeed = GetStickSpeed(leftStickInput) / 5.0f;
            rightStickSpeed = GetStickSpeed(rightStickInput);
        }
        else
        {
            leftStickInput = new Vector2(Input.GetAxis("LeftStickX"), Input.GetAxis("LeftStickY"));
            rightStickInput = new Vector2(Input.GetAxis("RightStickX"), Input.GetAxis("RightStickY"));

            leftStickRotation = -GetStickRotation(leftStickInput, prevLeftStickInput);
            rightStickRotation = -GetStickRotation(rightStickInput, prevRightStickInput);
            leftStickSpeed = GetStickSpeed(leftStickInput);
            rightStickSpeed = GetStickSpeed(rightStickInput);



        }

    
        // 获取左摇杆的旋转方向和速度

        /* if (leftStickInput.magnitude < deadZone)
         {
             leftStickInput = Vector2.zero;
         }

         // Apply dead zone to right stick input
         if (rightStickInput.magnitude < deadZone)
         {
             rightStickInput = Vector2.zero;
         }*/
        // 打印左摇杆信息
        if (Mathf.Abs(leftStickRotation) >= angleThreshold)
        {
            direction = Mathf.Sign(leftStickRotation);
            speed = Mathf.Abs(leftStickSpeed) * 8f;
            // 打印左摇杆信息
           

                PlayerController.isMoveL = true;
 
        }
        else
        {
            direction = 0f;
            speed = 0f;
            PlayerController.isMoveL = false;
        }

        

        if (Mathf.Abs(rightStickRotation) >= angleThreshold)
        {
            direction2 = Mathf.Sign(rightStickRotation);
            speed2 = Mathf.Abs(rightStickSpeed);
            PlayerController.isMoveR = true;
            // 打印左摇杆信息

        }
        else
        {
            direction2 = 0f;
            speed2 = 0f;
            PlayerController.isMoveR = false;
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
