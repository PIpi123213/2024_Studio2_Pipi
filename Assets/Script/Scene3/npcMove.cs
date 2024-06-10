using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f; // �ƶ��ٶ�
    private bool movingRight = true; // ��ǰ�ƶ�����
    private float currentspeed = 0f;

    public GameObject police;
    public GameObject find;
    private bool isPaused = false;

    private Animator animator;
    private void Start()
    {
        currentspeed = speed;
        animator = police.GetComponent<Animator>();
       

    }
    void Update()
    {
        // �ƶ�����
        if (!TimelineScene3.isLose)
        {
            float move = speed * Time.deltaTime;
            transform.Translate(movingRight ? move : -move, 0, 0);
        }
           
             
        




        




    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (TimelineScene3.isGameStart )
        {
            if (other.CompareTag("PointA"))
            {
                speed = Random.Range(0.4f, 0.7f);
                currentspeed = speed;
                // ��λ A����������Ƿ�ת��
                if (Random.value > 0.7f)
                {

                    Flip();
                }
                if(Random.value > 0.3f)
                {
                    StartCoroutine(PauseMovement(Random.Range(1f, 2f)));
                }




             
            }
            else if (other.CompareTag("PointB"))
            {
                // ��λ B������ת��
                speed = Random.Range(0.4f, 0.7f);
                currentspeed = speed;
                Flip();
                if (Random.value > 0.7f)
                {
                    StartCoroutine(PauseMovement(Random.Range(1f, 2f)));
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
    IEnumerator PauseMovement(float duration)
    {
        isPaused = true;
        speed = 0f;
        animator.SetBool("isStop",true);
        yield return new WaitForSeconds(duration);
        animator.SetBool("isStop", false);
        isPaused = false;
        speed = currentspeed; 
        
        // ��ͣ��ָ�ԭʼ�ٶ�
    }
    void Flip()
    {
        // ��ת������ƶ�����
        //speed = 0.01f;



        movingRight = !movingRight;
        Vector3 theScale = police.transform.localScale;
        theScale.x *= -1;
        police.transform.localScale = theScale;

        Quaternion theRotation = find.transform.rotation;

        // ����Ԫ��ת��Ϊŷ���ǣ�Euler Angles��
        Vector3 eulerAngle = theRotation.eulerAngles;

        // �����ת�Ƕ�
        if (Mathf.Abs(eulerAngle.y - 180f) < 0.01f) // ע��Ƚϵľ���
        {
            // ����Ϊ0��
            eulerAngle.y = 0f;
        }
        else
        {
            // ����Ϊ180��
            eulerAngle.y = 180f;
        }

        // ���޸ĺ��ŷ����ת������Ԫ��
        theRotation = Quaternion.Euler(eulerAngle);

        // Ӧ���µ���ת
        find.transform.rotation = theRotation;
    }
}
