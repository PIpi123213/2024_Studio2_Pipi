using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBoat : MonoBehaviour
{
    // Start is called before the first frame update
    public float force = 5f; // 推力大小
    //public float scaleChangeRate = 0.1f;
    public int scaleChangeInterval = 20;
    private Rigidbody2D rb;
    private Transform left;
    private Transform right;

    private float targetScale;
    private Vector3 initialScale;
    private int scaleChangeCounter = 0;

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

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ApplyForce(left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ApplyForce(right);
        }
    }



    void ApplyForce(Transform side)
    {
        Vector2 forceDirection = transform.up;
        rb.AddForceAtPosition(forceDirection.normalized * force, side.position, ForceMode2D.Impulse);
    }
}
