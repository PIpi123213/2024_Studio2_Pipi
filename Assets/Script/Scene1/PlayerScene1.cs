using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScene1 : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Char
    {
        Option1 = 1,
        Option2 = 2
    }
    public Char characterChoice;
    public float speedRate =200f;
    private float horizontalInput1;
    private float cspeed;

    public float speedRate_Joystick = 1.5f;
    private float horizontalInput1_Joystick;
    private float cspeed_Joystick;

    public float smoothness = 10.0f;
    private Animator animator;
    public GameObject T_hand;
    private Transform T_handtransform;
    private Transform Current_T_handtransform;
    public bool isMoving;
    private float inputTimeout = 0.7f;
    private float lastInputTime;
    private float previousRotation = 0f;

    public FishingLine fishingLine;



    private void Start()
    {
        animator = GetComponent<Animator>();
        if(characterChoice == Char.Option2)
        {
            T_hand = null;
        }
        T_hand.gameObject.SetActive(false);
        T_handtransform = T_hand.transform.Find("R_shoulder");
        Current_T_handtransform = T_handtransform;

        if (characterChoice == Char.Option1)
        {
            fishingLine = null;
        }














    }





    void Update()
    {
        

        if (characterChoice == Char.Option1)
        {
            cspeed = arduino123.speed / speedRate;
            horizontalInput1 = arduino123.direction;
        }
        else
        {
            cspeed = arduino123.speed2 / speedRate;
            horizontalInput1 = arduino123.direction2;

        }

        if (characterChoice == Char.Option1)
        {
            cspeed_Joystick = input11.speed / speedRate_Joystick;
            horizontalInput1_Joystick = input11.direction;
        }
        else
        {
            cspeed_Joystick = input11.speed2 / speedRate_Joystick;
            horizontalInput1_Joystick = input11.direction2;

        }

        if (cspeed_Joystick > 0f && characterChoice == Char.Option1)
        {
            MoveWithControllerPlayer1_Joystick();

        }
        if(characterChoice == Char.Option1)
        {
            if (horizontalInput1_Joystick < 0f)//1号玩家JOystick
            {

                isMoving = true;
                animator.SetBool("isDiging", true);
                lastInputTime = Time.time;
                T_hand.gameObject.SetActive(true);
                animator.SetFloat("DigSpeed", cspeed_Joystick);
                T_handtransform = Current_T_handtransform;
            }
            else if (horizontalInput1_Joystick == 0f)
            {
                if (Time.time - lastInputTime > inputTimeout)
                {
                    isMoving = true;
                    animator.SetBool("isDiging", true);
                    T_hand.gameObject.SetActive(true);
                    T_handtransform = Current_T_handtransform;


                }

            }
            else
            {
                isMoving = false;
                animator.SetBool("isDiging", false);
                T_hand.gameObject.SetActive(false);
                animator.SetFloat("PushupSpeed", cspeed_Joystick * 1.5f);
                lastInputTime = Time.time;

            }
        }
       











        //Debug.Log(cspeed_Joystick);


        
        if(characterChoice == Char.Option2)
        {
            fishingLine.currentropeLength = fishingLine.currentropeLength + (horizontalInput1_Joystick * cspeed_Joystick )*0.7f;
            MoveWithControllerPlayer2_Joystick();






        }














    }

    private void FixedUpdate()
    {

       



    }












    
    private void MoveWithControllerPlayer1_Joystick()
    {


        float rotationAmount = horizontalInput1_Joystick * cspeed_Joystick * Time.deltaTime * 1200f;

        // 计算新的旋转角度
       
        if (cspeed_Joystick >= 0f)
        {

            T_handtransform.Rotate(0f, 0f, rotationAmount, Space.Self);


          /*  Quaternion currentRotation = T_handtransform.rotation;

            // 计算目标旋转
            Quaternion targetRotation = currentRotation * Quaternion.Euler(0f, 0f, rotationAmount);

            // 使用插值方法逐渐改变物体的旋转
            T_handtransform.rotation = Quaternion.Lerp(currentRotation, targetRotation, Time.deltaTime * cspeed_Joystick *30f);*/
        }

    }

    private void MoveWithControllerPlayer2_Joystick()
    {


        float rotationAmount = -horizontalInput1_Joystick * cspeed_Joystick * Time.deltaTime * 600f;

        // 计算新的旋转角度

        if (cspeed_Joystick >= 0f)
        {
            fishingLine.point.Rotate(0f, 0f, rotationAmount, Space.Self);
            

            /*  Quaternion currentRotation = T_handtransform.rotation;

              // 计算目标旋转
              Quaternion targetRotation = currentRotation * Quaternion.Euler(0f, 0f, rotationAmount);

              // 使用插值方法逐渐改变物体的旋转
              T_handtransform.rotation = Quaternion.Lerp(currentRotation, targetRotation, Time.deltaTime * cspeed_Joystick *30f);*/
        }

    }

    // 通过插值方法逐渐改变物体的旋转


}











