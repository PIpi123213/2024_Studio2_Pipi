using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f; // 移动速度
    private bool movingRight = true; // 当前移动方向
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
        // 移动物体
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
                // 点位 A：随机决定是否转向
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
                // 点位 B：必须转向
                speed = Random.Range(0.4f, 0.7f);
                currentspeed = speed;
                Flip();
                if (Random.value > 0.7f)
                {
                    StartCoroutine(PauseMovement(Random.Range(1f, 2f)));
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
    IEnumerator PauseMovement(float duration)
    {
        isPaused = true;
        speed = 0f;
        animator.SetBool("isStop",true);
        yield return new WaitForSeconds(duration);
        animator.SetBool("isStop", false);
        isPaused = false;
        speed = currentspeed; 
        
        // 暂停后恢复原始速度
    }
    void Flip()
    {
        // 翻转物体的移动方向
        //speed = 0.01f;



        movingRight = !movingRight;
        Vector3 theScale = police.transform.localScale;
        theScale.x *= -1;
        police.transform.localScale = theScale;

        Quaternion theRotation = find.transform.rotation;

        // 将四元数转换为欧拉角（Euler Angles）
        Vector3 eulerAngle = theRotation.eulerAngles;

        // 检查旋转角度
        if (Mathf.Abs(eulerAngle.y - 180f) < 0.01f) // 注意比较的精度
        {
            // 设置为0度
            eulerAngle.y = 0f;
        }
        else
        {
            // 设置为180度
            eulerAngle.y = 180f;
        }

        // 将修改后的欧拉角转换回四元数
        theRotation = Quaternion.Euler(eulerAngle);

        // 应用新的旋转
        find.transform.rotation = theRotation;
    }
}
