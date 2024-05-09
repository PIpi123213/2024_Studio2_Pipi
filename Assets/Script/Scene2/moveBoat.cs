using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBoat : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float reduceforcerate = 0.1f;
    public float speedRate = 1000f;


    private float leftforce = 0f;
    private float rightforce = 0f;
    
    public int scaleChangeInterval = 20;
    private Rigidbody2D rb;
    private Transform left;
    private Transform right;

    private float targetScale;
    private Vector3 initialScale;
    private int scaleChangeCounter = 0;
    public float forceCurrent = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        left = transform.Find("left");
        right = transform.Find("right");

        initialScale = transform.localScale;
        
    }

    void FixedUpdate()
    {
        //transform.localScale = Vector3.Lerp(transform.localScale, initialScale * targetScale, scaleChangeRate * Time.fixedDeltaTime);
        //增加一些动态感觉
        if (scaleChangeCounter >= scaleChangeInterval)
        {
            targetScale = Random.Range(0.99f, 1.01f);
            scaleChangeCounter = 0;
        }
        else
        {
            scaleChangeCounter++;
        }

        // 直接改变大小
        transform.localScale = initialScale * targetScale;



    }
    private void Update()
    {
        if (leftforce > 0) {
            leftforce = leftforce - reduceforcerate;
        }
        else {
            leftforce = 0;
        }
        if (rightforce > 0) {
            rightforce = rightforce - reduceforcerate;
        }
        else {
            rightforce = 0;
        }



        if (arduino123.speed>=10.0f)
        {
            leftforce = arduino123.speed / speedRate;
            float min = 0f;
            float max = 0.5f;
            leftforce = Mathf.Clamp(leftforce, min, max);
            //Debug.Log(" leftforce: " + leftforce);
            ApplyForce(left, arduino123.direction,leftforce);
        }
        if (arduino123.speed2 >= 10.0f)
        {
            rightforce = arduino123.speed2 / speedRate;
            float min = 0f;
            float max = 0.5f;
            rightforce = Mathf.Clamp(rightforce, min, max);
            ApplyForce(right, -arduino123.direction2,rightforce);
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
            speedRate = 3000f;
        }





    }
    private void OnTriggerExit2D(Collider2D other) {
        Debug.Log("out");
        if (other.CompareTag("Plant")) {
            speedRate = 1000f;
        }
    }






    void ApplyForceTowardsPlant(Transform current) {
        Vector2 forceDirection = (current.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().AddForce(forceDirection * forceCurrent, ForceMode2D.Impulse);
    }





}
