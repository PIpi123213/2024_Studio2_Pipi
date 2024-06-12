using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
   

    public FishingLine fishingLine;
    public Slider slider;
    public float sliderRate;
    private bool isDiging = false;

    private bool isReady = false;

    public GameObject poster1;
    public GameObject poster2;

    public GameObject lineMove;



    private void Start()
    {
        animator = GetComponent<Animator>();
        if(characterChoice == Char.Option2)
        {
            T_hand = null;
            poster1 = null;
            poster2 = null;
        }
       
        if (characterChoice == Char.Option1)
        {
            fishingLine = null;
            T_hand.gameObject.SetActive(false);
            T_handtransform = T_hand.transform.Find("R_shoulder");
            Current_T_handtransform = T_handtransform;
            poster1.SetActive(true);
            poster2.SetActive(false);
            lineMove = null;
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
            horizontalInput1_Joystick = -input11.direction2;

        }

        if (cspeed_Joystick > 0f && characterChoice == Char.Option1 &&isMoving)
        {
            MoveWithControllerPlayer1_Joystick();

        }
        if (cspeed > 20f / speedRate && characterChoice == Char.Option1 && isMoving) {
            MoveWithControllerPlayer1();

        }


        if(characterChoice == Char.Option1 ) {
          

                slider.value -= sliderRate / (cspeed*10f + 1 + cspeed_Joystick);

          
        }








        if (characterChoice == Char.Option1 && Timelinescene1.isGameStart)
        {
            if (horizontalInput1_Joystick < 0f)//1号玩家JOystick
            {
                isDiging = true;
                isMoving = true;
                Find.isMoving = true;
                Find.isDiging = true;
                animator.SetBool("isDiging", true);
                lastInputTime = Time.time;
                T_hand.gameObject.SetActive(true);
                animator.SetFloat("DigSpeed", cspeed_Joystick);
                T_handtransform = Current_T_handtransform;
                poster1.SetActive(false);
                poster2.SetActive(true);
            }
            else if (horizontalInput1_Joystick == 0f)
            {

                if (Time.time - lastInputTime > inputTimeout)
                {
                    //Debug.Log("666666");
                    Find.isMoving = true;
                    isDiging = false;
                    isMoving = true;
                    Find.isDiging = false;
                    animator.SetBool("isDiging", true);
                    T_hand.gameObject.SetActive(true);
                    T_handtransform = Current_T_handtransform;
                    poster1.SetActive(false);
                    poster2.SetActive(true);

                }

            }
            else
            {
                Find.isDiging = false;
                Find.isMoving = false;
                isDiging = false;
                isMoving = false;
                animator.SetBool("isDiging", false);
                T_hand.gameObject.SetActive(false);
                animator.SetFloat("PushupSpeed", cspeed_Joystick * 1.5f);
                lastInputTime = Time.time;
                poster1.SetActive(true);
                poster2.SetActive(false);
            }





            if (horizontalInput1 < 0f)//1号玩家JOystick
            {
                isDiging = true;
                Find.isMoving = true;
                isMoving = true;
                animator.SetBool("isDiging", true);
                lastInputTime = Time.time;
                T_hand.gameObject.SetActive(true);
                //animator.SetFloat("DigSpeed", cspeed_Joystick);
                T_handtransform = Current_T_handtransform;
                poster1.SetActive(false);
                poster2.SetActive(true);
            }
            else if (horizontalInput1 ==0f) {
                if (Time.time - lastInputTime > inputTimeout) {
                    Find.isMoving = true;
                    isDiging = false;
                    isMoving = true;
                    animator.SetBool("isDiging", true);
                    T_hand.gameObject.SetActive(true);
                    T_handtransform = Current_T_handtransform;
                    poster1.SetActive(false);
                    poster2.SetActive(true);

                }

            }
            else {
                Find.isMoving = false;
                isDiging = false;
                isMoving = false;
                animator.SetBool("isDiging", false);
                T_hand.gameObject.SetActive(false);
                animator.SetFloat("PushupSpeed", cspeed * 3f);
                lastInputTime = Time.time;
                poster1.SetActive(true);
                poster2.SetActive(false);
            }



        }
      
        if(characterChoice == Char.Option2 && Timelinescene1.isGameStart)
        {
            fishingLine.currentropeLength = fishingLine.currentropeLength + (horizontalInput1_Joystick * cspeed_Joystick )*1f;
            fishingLine.currentropeLength = fishingLine.currentropeLength + (horizontalInput1 * cspeed) * 1f;
            fishingLine.currentropeLength = Mathf.Clamp(fishingLine.currentropeLength, 140f, 380f);

            MoveWithControllerPlayer2_Joystick();

            MoveWithControllerPlayer2();




        }

        if ( Timelinescene1.isGameStart&& GameManager.instance.gameMode == GameManager.GameMode.DialogueMoment)
        {
            if (cspeed != 0)
            {
                if (!isReady)
                {
                    Timelinescene1.isReady_timeline2++;
                    isReady = true;
                }
               
            }
            if (cspeed_Joystick != 0)
            {
                if (!isReady)
                {
                    Timelinescene1.isReady_timeline2++;
                    isReady = true;
                }
            }



        }












    }

    private void FixedUpdate()
    {

       



    }












    
  

    private void MoveWithControllerPlayer2_Joystick()
    {


        float rotationAmount = -horizontalInput1_Joystick * cspeed_Joystick * Time.deltaTime * 600f;
        Vector3 newPosition = lineMove.transform.position + new Vector3(0, horizontalInput1_Joystick * cspeed_Joystick * Time.deltaTime , 0);

        // 应用新的位置

        // 计算新的旋转角度
        newPosition.y = Mathf.Clamp(newPosition.y, -1f, 1f);
        if (cspeed_Joystick >= 30f/speedRate)
        {
            fishingLine.point.Rotate(0f, 0f, rotationAmount, Space.Self);
            lineMove.transform.position = newPosition;

            /*  Quaternion currentRotation = T_handtransform.rotation;

              // 计算目标旋转
              Quaternion targetRotation = currentRotation * Quaternion.Euler(0f, 0f, rotationAmount);

              // 使用插值方法逐渐改变物体的旋转
              T_handtransform.rotation = Quaternion.Lerp(currentRotation, targetRotation, Time.deltaTime * cspeed_Joystick *30f);*/
        }

    }
    private void MoveWithControllerPlayer1_Joystick()
    {


        float rotationAmount = horizontalInput1_Joystick * cspeed_Joystick * Time.deltaTime * 1500f;

        // 计算新的旋转角度

        if (cspeed >= 20f / speedRate)
        {

            T_handtransform.Rotate(0f, 0f, rotationAmount, Space.Self);


            /*  Quaternion currentRotation = T_handtransform.rotation;

              // 计算目标旋转
              Quaternion targetRotation = currentRotation * Quaternion.Euler(0f, 0f, rotationAmount);

              // 使用插值方法逐渐改变物体的旋转
              T_handtransform.rotation = Quaternion.Lerp(currentRotation, targetRotation, Time.deltaTime * cspeed_Joystick *30f);*/
        }

    }

    private void MoveWithControllerPlayer1() {


        float rotationAmount = horizontalInput1 * cspeed * Time.deltaTime * 1200f;

        // 计算新的旋转角度

        if (cspeed >= 20f / speedRate) {

            T_handtransform.Rotate(0f, 0f, rotationAmount, Space.Self);


            /*  Quaternion currentRotation = T_handtransform.rotation;

              // 计算目标旋转
              Quaternion targetRotation = currentRotation * Quaternion.Euler(0f, 0f, rotationAmount);

              // 使用插值方法逐渐改变物体的旋转
              T_handtransform.rotation = Quaternion.Lerp(currentRotation, targetRotation, Time.deltaTime * cspeed_Joystick *30f);*/
        }

    }

    private void MoveWithControllerPlayer2() {


        float rotationAmount = -horizontalInput1 * cspeed * Time.deltaTime * 800f;

        // 计算新的旋转角度

        Vector3 newPosition = lineMove.transform.position + new Vector3(0, horizontalInput1_Joystick * cspeed_Joystick * Time.deltaTime, 0);

        // 应用新的位置

        // 计算新的旋转角度
        newPosition.y = Mathf.Clamp(newPosition.y, -1f, 1f);
        if (cspeed_Joystick >= 30f / speedRate)
        {
            fishingLine.point.Rotate(0f, 0f, rotationAmount, Space.Self);
            lineMove.transform.position = newPosition;

            /*  Quaternion currentRotation = T_handtransform.rotation;

              // 计算目标旋转
              Quaternion targetRotation = currentRotation * Quaternion.Euler(0f, 0f, rotationAmount);

              // 使用插值方法逐渐改变物体的旋转
              T_handtransform.rotation = Quaternion.Lerp(currentRotation, targetRotation, Time.deltaTime * cspeed_Joystick *30f);*/
        }

    }

    // 通过插值方法逐渐改变物体的旋转


}











