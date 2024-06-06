using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PoliceMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f; // 移动速度
    private bool movingRight = true; // 当前移动方向
    private float currentspeed = 0f;

    public GameObject police;
    public GameObject find;

    public GameObject ploicePosition;
    public Vector3 ploicePosition1;
    private Animator animator;
    private void Start()
    {
        currentspeed = speed;
        animator = police.GetComponent<Animator>();
        ploicePosition.SetActive(false);

    }
    void Update()
    {
        // 移动物体
        if (Timelinescene11.isGameStart)
        {
            if (Timelinescene11.isWin_scene1 == 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, ploicePosition1, speed * Time.deltaTime);
                if(ploicePosition1.x > transform.position.x)
                {
                    if (!movingRight)
                    {
                        movingRight = !movingRight;
                        Vector3 theScale = police.transform.localScale;
                        theScale.x *= -1;
                        police.transform.localScale = theScale;
                    }



                }
                else if (ploicePosition1.x == transform.position.x)
                {
                    if (movingRight)
                    {
                        movingRight = !movingRight;
                        Vector3 theScale = police.transform.localScale;
                        theScale.x *= -1;
                        police.transform.localScale = theScale;
                    }
                    animator.SetBool("isStop", true);

                    Timelinescene11.play2schel = true;


                }
                else
                {
                    if (movingRight)
                    {
                        movingRight = !movingRight;
                        Vector3 theScale = police.transform.localScale;
                        theScale.x *= -1;
                        police.transform.localScale = theScale;
                    }




                }
            }
            else
            {
                float move = speed * Time.deltaTime;
                transform.Translate(movingRight ? move : -move, 0, 0);
            }
            
            


        }
           
        
       
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Timelinescene11.isGameStart)
        {
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

        // 检查碰撞的点位类型



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
        Vector3 theScale = police.transform.localScale;
        theScale.x *= -1;
        police.transform.localScale = theScale;

        Vector3 theScale1 = find.transform.localScale;
        theScale1.x *= -1;
        find.transform.localScale = theScale1;
    }
}
