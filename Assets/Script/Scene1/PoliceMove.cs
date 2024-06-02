using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f; // �ƶ��ٶ�
    private bool movingRight = true; // ��ǰ�ƶ�����
    private float currentspeed = 0f;



    private void Start()
    {
        currentspeed = speed;

    }
    void Update()
    {
        // �ƶ�����
        if (Timelinescene1.isGameStart2)
        {
            float move = speed * Time.deltaTime;
            transform.Translate(movingRight ? move : -move, 0, 0);
        }
       
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        



        // �����ײ�ĵ�λ����
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
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
