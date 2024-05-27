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
    
    // Update is called once per frame
    void Update()
    {
        MoveWithController();




    }
    private float previousRotation = 0f;
    private void MoveWithController() {
       
      
        float rotationAmount = -arduino123.direction * arduino123.speed  * Time.deltaTime * 1.2f;

        // 计算新的旋转角度
        float targetRotation = previousRotation + rotationAmount;
        if (arduino123.speed > 5.0f) {
            transform.Rotate(0f, 0f, rotationAmount);
            Quaternion targetQuaternion = Quaternion.Euler(0f, 0f, targetRotation);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetQuaternion, Time.deltaTime * smoothness);
            previousRotation = targetRotation;
        }


        // 通过插值方法逐渐改变物体的旋转


    }





}
