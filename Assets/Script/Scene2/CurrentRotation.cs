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
        // 初始化随机旋转速率，范围可以根据需要调整
        rotationSpeed = Random.Range(-RotationSpeed, RotationSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // 每帧更新物体的旋转角度
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }


}
