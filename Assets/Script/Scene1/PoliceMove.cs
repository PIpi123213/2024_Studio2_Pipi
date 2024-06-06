using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PoliceMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f; // �ƶ��ٶ�
    private bool movingRight = true; // ��ǰ�ƶ�����
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
        // �ƶ�����
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
                // ��λ A����������Ƿ�ת��
                if (Random.value > 0.7f)
                {

                    Flip();
                }

            }
            else if (other.CompareTag("PointB"))
            {
                // ��λ B������ת��
                speed = Random.Range(0.2f, 0.4f);
                Flip();
            }
            else if (other.CompareTag("PointC"))
            {
                // ��λ B������ת��
                speed = Random.Range(0.2f, 0.4f);
                if (Random.value > 0.5f)
                {

                    Flip();
                }
            }

        }

        // �����ײ�ĵ�λ����



    }




    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("PointA"))
        {
            // ��λ A����������Ƿ�ת��
            //speed = currentspeed;

        }
        else if (other.CompareTag("PointB"))
        {
            // ��λ B������ת��
           // speed = currentspeed;
        }


    }


    void Flip()
    {
        // ��ת������ƶ�����
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
