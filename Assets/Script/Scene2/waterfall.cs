using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterfall : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; // 目标物体
    public float forceMultiplier = 1f; // 力的倍数
    public float speed = 5f; // 移动和旋转速度
    public static bool iswin=false;
    public GameObject point1;
    public Transform point;
    public Transform player;
    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.CompareTag("Player")) // 假设是玩家物体
        {
            iswin = true;
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null && target != null)
            {
                Vector2 direction = target.position - other.transform.position;
                float distance = direction.magnitude;
                direction.Normalize();
                rb.AddForce(direction * forceMultiplier / distance, ForceMode2D.Impulse);
                Debug.Log("11");
               




            }
        }
    }

    private void Start()
    {
        iswin = false;
    }


    void MoveAndRotateTowards(Transform target1)
    {
        // 移动物体位置
        Vector3 direction = (target1.position - player.transform.position).normalized;
        player.transform.position = Vector3.MoveTowards(player.transform.position, target1.position, speed * Time.deltaTime);

        // 计算目标方向
        float rotationZ = target1.transform.rotation.eulerAngles.z;
        Quaternion targetRotation = Quaternion.Euler(0, 0, rotationZ);
        Quaternion currentRotation = player.transform.rotation;
        // 计算目标旋转角度

        player.transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, 0.1f);
        // 应用新的旋转角度
       
        
    }
    private void Update()
    {
        if (player.transform.position== point1.transform.position && Mathf.Abs(player.transform.rotation.eulerAngles.z - point1.transform.rotation.eulerAngles.z)<1f)
        {
            TimelineControllerScene2.isWin = true;
            Debug.Log("win");


        }
        if (iswin)
        {
            MoveAndRotateTowards(point1.transform);
        }
      
    }






}
