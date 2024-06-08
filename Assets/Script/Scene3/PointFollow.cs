using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;

    // 相对位置
    private Vector3 relativePosition;

    void Start() {
        // 计算初始的相对位置
        if (target != null) {
            relativePosition = transform.position - target.position;
        }
    }

    void Update() {
        // 如果目标对象存在
        if (target != null) {
            // 计算新的位置，但只更新 x 坐标，保持 y 坐标不变
            Vector3 newPosition = transform.position;
            newPosition.x = target.position.x + relativePosition.x;
            newPosition.y = target.position.y + relativePosition.y;
            transform.position = newPosition;
        }
    }
}
