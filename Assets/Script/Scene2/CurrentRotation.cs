using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRotation : MonoBehaviour
{
    // Start is called before the first frame update
    private float rotationSpeed;
    public float RotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        // ��ʼ�������ת���ʣ���Χ���Ը�����Ҫ����
        rotationSpeed = Random.Range(-RotationSpeed, RotationSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // ÿ֡�����������ת�Ƕ�
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }


}
