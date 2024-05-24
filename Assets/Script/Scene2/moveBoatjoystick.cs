using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBoatjoystick : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float reduceForcerate_Joystick = 0.001f;
    public float speedRate_Joystick = 4f;
    private float rspeedRate_Joystick = 4f;


    private float leftforce_Joystick = 0f;
    private float leftdirection_Joystick = 0f;
    private float rightdirection_Joystick = 0f;
    private float rightforce_Joystick = 0f;
   


    //public int scaleChangeInterval = 20;
    private Rigidbody2D rb;
    private Transform left;
    private Transform right;

   
    private float forceCurrent = 10f;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        left = transform.Find("left");
        right = transform.Find("right");


        rspeedRate_Joystick = speedRate_Joystick;
    }

    void FixedUpdate()
    {
        //transform.localScale = Vector3.Lerp(transform.localScale, initialScale * targetScale, scaleChangeRate * Time.fixedDeltaTime);
        //增加一些动态感觉
        


    }
    private void Update()
    {







        leftforce_Joystick = input11.speed / speedRate_Joystick;
        leftdirection_Joystick = input11.direction;

        rightforce_Joystick = input11.speed2 / speedRate_Joystick;
        rightdirection_Joystick = input11.direction2;

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
            speedRate_Joystick = rspeedRate_Joystick * 2.0f;
        }





    }
    private void OnTriggerExit2D(Collider2D other) {
        Debug.Log("out");
        if (other.CompareTag("Plant")) {
            speedRate_Joystick = rspeedRate_Joystick;
        }
    }






    void ApplyForceTowardsPlant(Transform current) {
        currentforce currentForceScript = current.GetComponent<currentforce>();
        forceCurrent = currentForceScript.force;
        Vector2 forceDirection = current.up;
        
        GetComponent<Rigidbody2D>().AddForce(forceDirection * forceCurrent, ForceMode2D.Impulse);


    }





}
