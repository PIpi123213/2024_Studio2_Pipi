using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f; // 移动速度
    private bool movingRight = true; // 当前移动方向
    private float currentspeed = 0f;



    private void Start()
    {
        currentspeed = speed;

    }
    void Update()
    {
        // 移动物体
        if (Timelinescene1.isGameStart2)
        {
            float move = speed * Time.deltaTime;
            transform.Translate(movingRight ? move : -move, 0, 0);
        }
       
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        



        // 检查碰撞的点位类型
        if (other.CompareTag("PointA"))
        {
            speed = Random.Range(0.2f, 0.4f);
            // 点位 A：随机决定是否转向
            if (Random.value > 0.7f)
            {
                
                Flip();
            }
            
        }
        else if (other.CompareTag("PointB"))
        {
            // 点位 B：必须转向
            speed = Random.Range(0.2f, 0.4f);
            Flip();
        }
        else if (other.CompareTag("PointC"))
        {
            // 点位 B：必须转向
            speed = Random.Range(0.2f, 0.4f);
            if (Random.value > 0.5f)
            {

                Flip();
            }
        }



    }




    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("PointA"))
        {
            // 点位 A：随机决定是否转向
            //speed = currentspeed;

        }
        else if (other.CompareTag("PointB"))
        {
            // 点位 B：必须转向
           // speed = currentspeed;
        }


    }


    void Flip()
    {
        // 翻转物体的移动方向
        //speed = 0.01f;



        movingRight = !movingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
