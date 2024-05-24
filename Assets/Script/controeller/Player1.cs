using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player1 : MonoBehaviour
{


    public enum Char
    {
        Option1 = 1,
        Option2 = 2
    }
    public Char characterChoice;
    public float speedRate;
    private float horizontalInput1;
    private float cspeed;
    public float smoothness = 10.0f;
    private float forceCurrent;
    private Rigidbody2D rb;
    public float forceMagnitude = 0f;
    // Start is called before the first frame update
    public float forceIncreaseRate = 1f; // 力的增加速率
    private float forceIncreaseRateTemp = 1f;
    private float currentForce = 5f;

    public float rotationSpeed = 1f;
    private float returnSpeed = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        forceIncreaseRateTemp = forceIncreaseRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (characterChoice == Char.Option1)
        {
            cspeed = input11.speed / speedRate;
            horizontalInput1 = input11.direction;
        }
        else
        {
            cspeed = input11.speed2 / speedRate;
            horizontalInput1 = input11.direction2;

        }

        Quaternion currentRotation = transform.rotation;
        float currentZ = currentRotation.eulerAngles.z;
        Quaternion targetRotation;
        // 计算目标旋转角度
        if (cspeed != 0)
        {
            // 当 cspeed 非零时，按固定速度调整 z 轴旋转，方向由 cspeed 的正负决定
            float targetZ = currentZ + (horizontalInput1 * rotationSpeed * Time.deltaTime);
            targetRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y, targetZ);
            transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, 1); // 直接设置为目标旋转，避免 Lerp 的缓动效果
        }
        //UnityEngine.Debug.Log(cspeed);

        if (cspeed <= 0.04f)
        {
            targetRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y, 0);
            transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, returnSpeed * Time.deltaTime);
        }
        // 当 cspeed 为零时，平滑地将 z 轴旋转恢复到 0
        //



       /* currentForce += forceIncreaseRate * Time.deltaTime;

        // 限制当前施加的力不超过最大值
        currentForce = Mathf.Clamp(currentForce, 2f, forceMagnitude);



        // 施加力，方向为世界空间中的 Y 轴正方向，大小为 currentForce
        rb.AddForce(Vector3.up * currentForce);

*/


        MoveWithController();
    }





    private void MoveWithController()
    {


        float distanceToMove = horizontalInput1 * cspeed * 10 * Time.deltaTime;

        // 创建一个新的位置向量
        Vector3 newPosition = transform.position + new Vector3(distanceToMove, 0f, 0f);

        // 通过插值方法逐渐改变角色位置
        //transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * smoothness);
        // 限制角色移动范围

        Vector2 forceDirection = transform.right * horizontalInput1;
        rb.AddForce(forceDirection.normalized * cspeed, ForceMode2D.Impulse);

    }




   /* private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Current"))
        {
            ApplyForceTowardsPlant(other.transform);
        }

        if (other.gameObject.CompareTag("Plant"))
        {
            //speedRate = 3 * speedRateTemp;
            forceIncreaseRate = -forceIncreaseRate * 3;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("out");
        if (other.CompareTag("Plant"))
        {
            //speedRate = speedRateTemp;
            forceIncreaseRate = forceIncreaseRateTemp;
        }
    }






    void ApplyForceTowardsPlant(Transform current)
    {
        currentforce currentForceScript = current.GetComponent<currentforce>();
        forceCurrent = currentForceScript.force;
        Vector2 forceDirection = current.up;
        GetComponent<Rigidbody2D>().AddForce(forceDirection * forceCurrent, ForceMode2D.Impulse);


    }*/

}
