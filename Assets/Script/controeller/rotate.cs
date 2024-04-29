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

        // ����һ����ת�������Ԫ��
        
        Quaternion rotation = Quaternion.Euler(0f, 0f, rotationAmount);
        
        if (arduino123.speed >5.0f) {
            transform.Rotate(0f, 0f, rotationAmount);
        }*/
        float rotationAmount = -arduino123.direction * arduino123.speed  * Time.deltaTime * 1.2f;

        // �����µ���ת�Ƕ�
        float targetRotation = previousRotation + rotationAmount;

        if (arduino123.speed > 5.0f) {
            // ���µ���ת�Ƕȵ��ӵ�֮ǰ�ĽǶ���
            transform.Rotate(0f, 0f, rotationAmount);

            // ƽ���ش�֮ǰ�ĽǶ���ת���µĽǶ�
            Quaternion targetQuaternion = Quaternion.Euler(0f, 0f, targetRotation);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetQuaternion, Time.deltaTime * smoothness);

            // ����֮ǰ�ĽǶ�
            previousRotation = targetRotation;
        }


        // ͨ����ֵ�����𽥸ı��������ת


    }





}
