using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    // Start is called before the first frame update

    private float horizontalInput1_Joystick;
    private float cspeed_Joystick;
    public GameObject T_hand;
    private float previousRotation = 0f;


    public float smoothness = 10.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cspeed_Joystick = input11.speed ;
        horizontalInput1_Joystick = input11.direction;
        MoveWithControllerPlayer1_Joystick();
    }




    private void MoveWithControllerPlayer1_Joystick()
    {


        float rotationAmount = -horizontalInput1_Joystick * cspeed_Joystick * Time.deltaTime * 1000f;

        // 计算新的旋转角度
        float targetRotation = previousRotation + rotationAmount;
        if (cspeed_Joystick > 0f)
        {

            T_hand.transform.Rotate(0f, 0f, rotationAmount);
            /*Quaternion targetQuaternion = Quaternion.Euler(0f, 0f, targetRotation);
            T_hand.transform.rotation = Quaternion.Lerp(T_hand.transform.rotation, targetQuaternion, Time.deltaTime * smoothness);
            previousRotation = targetRotation;*/
        }


        // 通过插值方法逐渐改变物体的旋转


    }
}
