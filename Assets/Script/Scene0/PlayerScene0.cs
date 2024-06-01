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







    void Start()
    {
        animator = GetComponent<Animator>();
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
        
        if (slider.value < 1f)
        {
            slider.value = slider.value + (cspeed * horizontalInput1 / speedRate) + (cspeed_Joystick * horizontalInput1_Joystick / speedRate_Joystick)*Time.deltaTime;

        }
        else
        {
            if (!isready)
            {
                Uicontroller.playerReady++;
                isready= true;
            }

        }
        if (Uicontroller.isStart)
        {
           


        }








    }


    public void stopanimation()
    {
        animator.SetBool("isStart", true);




    }
}
