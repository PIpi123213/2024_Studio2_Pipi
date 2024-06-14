using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveBoat : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float reduceForcerate = 0.001f;
    public float speedRate = 1000f;
    private float speedRateTemp = 0f;

    private float leftforce = 0f;
    private float leftdirection = 0f;
    private float rightdirection = 0f;
    private float rightforce = 0f;





    public float reduceForcerate_Joystick = 0.001f;
    public float speedRate_Joystick = 4f;
    private float rspeedRate_Joystick = 4f;


    private float leftforce_Joystick = 0f;
    private float leftdirection_Joystick = 0f;
    private float rightdirection_Joystick = 0f;
    private float rightforce_Joystick = 0f;


    private bool isready1 = false;
    private bool isready2 = false;

    public Slider slider1;
    public Slider slider2;










    private Rigidbody2D rb;
    private Transform left;
    private Transform right;

    /*private float targetScale;
    private Vector3 initialScale;
    private int scaleChangeCounter = 0;*/
    private float forceCurrent = 10f;
   


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        left = transform.Find("left");
        right = transform.Find("right");

        //initialScale = transform.localScale;
        speedRateTemp = speedRate;
        rspeedRate_Joystick = speedRate_Joystick;
    }

    void FixedUpdate()
    {
        //transform.localScale = Vector3.Lerp(transform.localScale, initialScale * targetScale, scaleChangeRate * Time.fixedDeltaTime);
        //增加一些动态感觉
        /*if (scaleChangeCounter >= scaleChangeInterval)
        {
            targetScale = Random.Range(0.99f, 1.01f);
            scaleChangeCounter = 0;
        }
        else
        {
            scaleChangeCounter++;
        }

        // 直接改变大小
        transform.localScale = initialScale * targetScale;*/




        if (!TimelineControllerScene2.isLose)
        {
            if (leftforce >= 20f / speedRate)
            {

                float min = 0f;
                float max = 1f;
                leftforce = Mathf.Clamp(leftforce, min, max);
                //Debug.Log(" leftforce: " + leftforce);
                ApplyForce(left, leftdirection, leftforce);
            }
            /* else {
                 if (currentleftforce >=0f) {
                     ApplyForce(left, currentleftdirection, currentleftforce*1.5f);
                     currentleftforce -= reduceForcerate * Time.deltaTime;

                 }

             }*/
            if (rightforce >= 20f / speedRate)
            {

                float min = 0f;
                float max = 1f;
                rightforce = Mathf.Clamp(rightforce, min, max);
                ApplyForce(right, -rightdirection, rightforce);

                //Debug.Log(" rightforce: " + rightforce);
            }




            if (leftforce_Joystick >= 0f)
            {


                float min = 0f;
                float max = 1f;
                leftforce_Joystick = Mathf.Clamp(leftforce_Joystick, min, max);
                // Debug.Log(" leftforce: " + leftforce);
                ApplyForce(left, leftdirection_Joystick, leftforce_Joystick);
            }

            if (rightforce_Joystick >= 0f)
            {


                float min = 0f;
                float max = 1f;
                rightforce_Joystick = Mathf.Clamp(rightforce_Joystick, min, max);
                ApplyForce(right, -rightdirection_Joystick, rightforce_Joystick);


            }
        }
       













    }
    private void Update()
    {

        leftforce_Joystick = input11.speed*0.9f / speedRate_Joystick;
        leftdirection_Joystick = input11.direction;
        rightforce_Joystick = input11.speed2 / speedRate_Joystick;
        rightdirection_Joystick = input11.direction2;

       



        leftforce = arduino123.speed / speedRate;
        rightforce = arduino123.speed2 / speedRate;
        leftdirection = arduino123.direction;
        rightdirection = arduino123.direction2;


        if (GameManager.instance.gameMode == GameManager.GameMode.DialogueMoment && TimelineControllerScene2.isLose)
        {
            if (slider1.value < 1f)
            {
                slider1.value = slider1.value + (leftforce*20f / speedRate) + (leftforce_Joystick * 20f / speedRate_Joystick) * Time.deltaTime;

            }
            else
            {
                if (!isready1)
                {
                    TimelineControllerScene2.isReady++;
                    isready1 = true;
                }



            }

            if (slider2.value < 1f)
            {
                slider2.value = slider2.value + (rightforce * 20f / speedRate) + (rightforce_Joystick * 20f / speedRate_Joystick) * Time.deltaTime;

            }
            else
            {
                if (!isready2)
                {
                    TimelineControllerScene2.isReady++;
                    isready2 = true;
                }



            }




        }
        if (GameManager.instance.gameMode == GameManager.GameMode.DialogueMoment && TimelineControllerScene2.isReady ==2)
        {
           GameManager.instance.ResumeTimeline();



        }








    }

    void ApplyForce(Transform side, float direction,float force )
    {
        Vector2 forceDirection = transform.up*direction;
        rb.AddForceAtPosition(forceDirection.normalized * force, side.position, ForceMode2D.Impulse);

    }


    private void OnTriggerEnter2D(Collider2D other) { 
        
        if (other.gameObject.CompareTag("Current")) {
            ApplyForceTowardsPlant(other.transform);
        }

        if (other.gameObject.CompareTag("Plant")) {
            speedRate = 3*speedRateTemp;
            speedRate_Joystick = 3 * rspeedRate_Joystick;
        }

        if (other.gameObject.CompareTag("END"))
        {
            Debug.Log("win");
            waterfall.win = true;
            GameManager.instance.gameMode = GameManager.GameMode.CGMoment;
        }



    }
    private void OnTriggerExit2D(Collider2D other) {
        Debug.Log("out");
        if (other.CompareTag("Plant")) {
            speedRate = speedRateTemp;
            speedRate_Joystick =  rspeedRate_Joystick;
        }
    }






    void ApplyForceTowardsPlant(Transform current) {
        currentforce currentForceScript = current.GetComponent<currentforce>();
        forceCurrent = currentForceScript.force;
        Vector2 forceDirection = current.up;
        GetComponent<Rigidbody2D>().AddForce(forceDirection * forceCurrent, ForceMode2D.Impulse);


    }





}
