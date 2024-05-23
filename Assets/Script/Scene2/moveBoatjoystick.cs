using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBoatjoystick : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float reduceForcerate = 0.001f;
    public float speedRate = 4f;
    private float rspeedRate = 4f;


    private float leftforce = 0f;
    private float leftdirection = 0f;
    private float rightdirection = 0f;
    private float rightforce = 0f;
   


    //public int scaleChangeInterval = 20;
    private Rigidbody2D rb;
    private Transform left;
    private Transform right;

    private float targetScale;
    private Vector3 initialScale;
    private int scaleChangeCounter = 0;
    private float forceCurrent = 10f;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        left = transform.Find("left");
        right = transform.Find("right");

        initialScale = transform.localScale;
        rspeedRate = speedRate;
    }

    void FixedUpdate()
    {
        //transform.localScale = Vector3.Lerp(transform.localScale, initialScale * targetScale, scaleChangeRate * Time.fixedDeltaTime);
        //增加一些动态感觉
        


    }
    private void Update()
    {
       






        leftforce = input11.speed / speedRate;
        leftdirection = input11.direction;

        rightforce = input11.speed2 / speedRate;
        rightdirection = input11.direction2;

        if (leftforce >=0f)
        {
           
            
            float min = 0f;
            float max = 1f;
            leftforce = Mathf.Clamp(leftforce, min, max);
           // Debug.Log(" leftforce: " + leftforce);
            ApplyForce(left, leftdirection, leftforce);
        }
        
        if (rightforce >=0f)
        {
            
            
            float min = 0f;
            float max = 1f;
            rightforce = Mathf.Clamp(rightforce, min, max);
            ApplyForce(right, -rightdirection, rightforce);
            
            //Debug.Log(" rightforce: " + rightforce);
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
            speedRate = rspeedRate*2.0f;
        }





    }
    private void OnTriggerExit2D(Collider2D other) {
        Debug.Log("out");
        if (other.CompareTag("Plant")) {
            speedRate = rspeedRate;
        }
    }






    void ApplyForceTowardsPlant(Transform current) {
        currentforce currentForceScript = current.GetComponent<currentforce>();
        forceCurrent = currentForceScript.force;
        Vector2 forceDirection = current.up;
        
        GetComponent<Rigidbody2D>().AddForce(forceDirection * forceCurrent, ForceMode2D.Impulse);


    }





}
