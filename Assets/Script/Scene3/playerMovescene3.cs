using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class playerMovescene3 : MonoBehaviour
{
    // Start is called before the first frame update
    public enum Char {
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

    public float smoothness = 10.0f;
    //private Animator animator;

    private Rigidbody2D rb;
    public Transform point;

    public bool isHiding;
    public bool isMoving;
    public bool isMovingFast;
    public Slider slider;
    private bool isready = false;
    private bool iswin = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
        

        //initialScale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        if (characterChoice == Char.Option1) {
            cspeed = arduino123.speed / speedRate;
            horizontalInput1 = -arduino123.direction;
            
        }
        else {
            cspeed = arduino123.speed2 / speedRate;
            horizontalInput1 = arduino123.direction2;

        }

        if (characterChoice == Char.Option1) {
            cspeed_Joystick = input11.speed / speedRate_Joystick;
            horizontalInput1_Joystick = input11.direction;
        }
        else {
            cspeed_Joystick = input11.speed2 / speedRate_Joystick;
            horizontalInput1_Joystick = input11.direction2;

        }
        Vector2 velocity = rb.velocity;

        // 计算速度的大小（即速度的标量值）
        float speed = velocity.magnitude;
        if (TimelineScene3.isLose)
        {
            rb.velocity = Vector2.zero;
        }
      // Debug.Log(speed);
        if (speed >=0.75f)
        {
            isMoving = true;



        }
        else
        {
            isMoving = false;
        }

        if (speed > 1.8f)
        {
            isMovingFast = true;


        }
        else
        {
            isMovingFast = false;
        }

        if(GameManager.instance.gameMode == GameManager.GameMode.DialogueMoment && TimelineScene3.isLose)
        {
            if (slider.value < 1f)
            {
                slider.value = slider.value + (cspeed*10f / speedRate) + (cspeed_Joystick*20f / speedRate_Joystick) * Time.deltaTime;

            }
            else
            {
                if (!isready)
                {
                    PlayerControllerScene3.isReady++;
                    isready = true;
                }



            }
        }


        









    }
    void FixedUpdate() {









        if (!TimelineScene3.isLose && !iswin)
        {
            if (cspeed >= 20f / speedRate)
            {

                float min = 0f;
                float max = 1f;

                ApplyForce(point, horizontalInput1, cspeed);
            }




            if (cspeed_Joystick >= 0f)
            {


                float min = 0f;
                float max = 1f;
                ApplyForce(point, horizontalInput1_Joystick, cspeed_Joystick);

            }

        }












    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shelter"))
        {
            isHiding = true;
        }
        if (collision.gameObject.CompareTag("Win"))
        {
            Debug.Log("1");
            iswin = true;
            TimelineScene3.isWin++;
        }



    }




    private void OnTriggerStay2D(Collider2D collision)
    {
        
   



    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shelter"))
        {
            isHiding = false;
        }

    }


    void ApplyForce(Transform side, float direction, float force) {
        Vector2 forceDirection = side.right * direction;
        rb.AddForceAtPosition(forceDirection.normalized * force, side.position, ForceMode2D.Impulse);

    }
}
