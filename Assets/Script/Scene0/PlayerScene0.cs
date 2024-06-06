using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScene0 : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Char
    {
        Option1 = 1,
        Option2 = 2
    }
    public Char characterChoice;
    public float speedRate = 200f;
    private float horizontalInput1;
    private float cspeed;

    public float speedRate_Joystick = 1.5f;
    private float horizontalInput1_Joystick;
    private float cspeed_Joystick;
    private Animator animator;
    public Slider slider;
    private bool isready = false;
    private bool isPlayed = false;

    public GameObject T_hand;
    private Transform T_handtransform;
   





    void Start()
    {
        animator = GetComponent<Animator>();
        if (characterChoice == Char.Option2)
        {
            T_hand = null;
        }

        if (characterChoice == Char.Option1)
        {
           
            T_hand.gameObject.SetActive(false);
            T_handtransform = T_hand.transform.Find("L_shoulder");
           

        }








    }

    // Update is called once per frame
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
        Debug.Log(cspeed_Joystick);
        if (slider.value < 1f)
        {
            slider.value = slider.value + (cspeed / speedRate) + (cspeed_Joystick  / speedRate_Joystick)*Time.deltaTime;

        }
        else
        {
            if (!isready)
            {
                Uicontroller.playerReady++;
                isready= true;
            }

        }
        if (Uicontroller.isStartGame && characterChoice == Char.Option1)
        {
            animator.SetBool("isStartGame", true);
            T_hand.gameObject.SetActive(true);

        }

        if (cspeed_Joystick > 0f && characterChoice == Char.Option1 && Uicontroller.isStartGame)
        {
            MoveWithControllerPlayer1_Joystick();
            if (!isPlayed&& GameManager.instance.gameMode == GameManager.GameMode.DialogueMoment)
            {
                Debug.Log("222");
                Uicontroller.played++;
                isPlayed= true;
            }
           
            
            animator.SetFloat("Speed", cspeed_Joystick * 0.5f);



        }
        if (cspeed > 20f / speedRate && characterChoice == Char.Option1 && Uicontroller.isStartGame)
        {
            if (!isPlayed && GameManager.instance.gameMode == GameManager.GameMode.DialogueMoment)
            {
                Debug.Log("222");
                Uicontroller.played++;
                isPlayed = true;
            }
            MoveWithControllerPlayer1();
            animator.SetFloat("Speed", cspeed * 0.8f);
        }



        if (cspeed_Joystick > 0f && characterChoice == Char.Option2 && Uicontroller.isStartGame)
        {
            if (!isPlayed && GameManager.instance.gameMode == GameManager.GameMode.DialogueMoment)
            {
                Debug.Log("222");
                Uicontroller.played++;
                isPlayed = true;
            }
            if (horizontalInput1_Joystick > 0f)
            {

                animator.SetBool("isLeft", true);
                animator.SetBool("isRight", false);
                animator.SetFloat("Speed", cspeed_Joystick * 0.5f + 1f) ;
                

            }
            else if(horizontalInput1_Joystick < 0f)
            {
                animator.SetBool("isRight", true);
                animator.SetBool("isLeft", false);
                animator.SetFloat("Speed2", cspeed_Joystick * 0.5f +1f);
                
            }
          
        }
        else if(cspeed_Joystick == 0f && characterChoice == Char.Option2 && Uicontroller.isStartGame)
        {
            animator.SetBool("isRight", false);
            animator.SetBool("isLeft", false);
        }














        if (cspeed > 20f / speedRate && characterChoice == Char.Option2 && Uicontroller.isStartGame)
        {
            if (!isPlayed && GameManager.instance.gameMode == GameManager.GameMode.DialogueMoment)
            {
                Debug.Log("222");
                Uicontroller.played++;
                isPlayed = true;
            }
            if (horizontalInput1 > 0f)
            {

                animator.SetBool("isLeft", true);
                animator.SetFloat("Speed", cspeed * 0.8f + 1f);

            }
            else if (horizontalInput1 < 0f)
            {
                animator.SetBool("isRight", true);
                animator.SetFloat("Speed2", cspeed * 0.8f + 1f);
            }
            else
            {
                animator.SetBool("isRight", false);
                animator.SetBool("isLeft", false);

            }
        }







    }


    public void stopanimation()
    {
        animator.SetBool("isStart", true);




    }









    private void MoveWithControllerPlayer1_Joystick()
    {


        float rotationAmount = horizontalInput1_Joystick * cspeed_Joystick  * Time.deltaTime * 600f;

        // 计算新的旋转角度

        if (cspeed_Joystick >= 0f)
        {

            T_handtransform.Rotate(0f, 0f, rotationAmount, Space.Self);

        }

    }

    private void MoveWithControllerPlayer1()
    {


        float rotationAmount = horizontalInput1 * cspeed * Time.deltaTime * 800f;

        // 计算新的旋转角度

        if (cspeed >= 20f / speedRate)
        {

            T_handtransform.Rotate(0f, 0f, rotationAmount, Space.Self);


        }

    }
}
