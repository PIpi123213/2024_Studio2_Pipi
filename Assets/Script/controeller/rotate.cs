using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float smoothness = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private float previousRotation = 0f;
    // Update is called once per frame
    void Update()
    {
        MoveWithController();




    }
    private void MoveWithController() {
       
        /*float rotationAmount = -arduino123.direction * arduino123.speed*100 * Time.deltaTime ;

        // 创建一个旋转方向的四元数
        
        Quaternion rotation = Quaternion.Euler(0f, 0f, rotationAmount);
        
        if (arduino123.speed >5.0f) {
            transform.Rotate(0f, 0f, rotationAmount);
        }*/
        float rotationAmount = -arduino123.direction * arduino123.speed  * Time.deltaTime * 1.2f;

        // 计算新的旋转角度
        float targetRotation = previousRotation + rotationAmount;

        if (arduino123.speed > 5.0f) {
            // 将新的旋转角度叠加到之前的角度上
            transform.Rotate(0f, 0f, rotationAmount);

            // 平滑地从之前的角度旋转到新的角度
            Quaternion targetQuaternion = Quaternion.Euler(0f, 0f, targetRotation);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetQuaternion, Time.deltaTime * smoothness);

            // 更新之前的角度
            previousRotation = targetRotation;
        }


        // 通过插值方法逐渐改变物体的旋转


    }





}
