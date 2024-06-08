using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;

    // ���λ��
    private Vector3 relativePosition;

    void Start() {
        // �����ʼ�����λ��
        if (target != null) {
            relativePosition = transform.position - target.position;
        }
    }

    void Update() {
        // ���Ŀ��������
        if (target != null) {
            // �����µ�λ�ã���ֻ���� x ���꣬���� y ���겻��
            Vector3 newPosition = transform.position;
            newPosition.x = target.position.x + relativePosition.x;
            newPosition.y = target.position.y + relativePosition.y;
            transform.position = newPosition;
        }
    }
}
