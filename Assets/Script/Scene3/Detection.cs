using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player1;            // ��һ�����
    public Transform player2;            // �ڶ������
    public float detectionRange = 10f;   // ��ⷶΧ
    public float fieldOfView = 45f;      // ��Ұ�Ƕ�
    public LayerMask playerLayer;        // ��Ҳ�
    public LayerMask obstaclesLayer;     // �����

    public bool isFind = false;
    private void Update()
    {
        DetectPlayer(player1);
        DetectPlayer(player2);
    }

    bool DetectPlayer(Transform player)
    {
        // ���㾯������֮��ľ���
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // �������ڼ�ⷶΧ��
        if (distanceToPlayer <= detectionRange)
        {
            // ����Ӿ��쵽��ҵķ���
            Vector2 directionToPlayer = (player.position - transform.position).normalized;
            float angleToPlayer = Vector2.Angle(transform.right, directionToPlayer);

            // �������Ƿ�����Ұ׶��
            if (angleToPlayer <= fieldOfView / 2)
            {
                // ����һ���Ӿ��쵽��ҵ����ߣ�ֻ�����Ҳ���ϰ����
                RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, detectionRange, playerLayer | obstaclesLayer);

                // ������Ϣ����ʾ���߼����
                Debug.DrawLine(transform.position, player.position, Color.red);

                // ��������Ƿ�������κ�����
                if (hit.collider != null)
                {
                    Debug.Log("���߻�����: " + hit.collider.gameObject.name);
                    // ��������Ƿ���������
                    if (((1 << hit.collider.gameObject.layer) & playerLayer) != 0)
                    {
                        Debug.Log($"��� {player.name} �����֣�");
                        // �����������ұ����ֺ�Ĵ����߼�
                        return true;
                    }
                    else
                    {
                        Debug.Log("����δ������ң������������赲��");
                        return false;
                    }
                }
                else
                {
                    Debug.Log("����û�л����κ�����");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    // ��ѡ���ڱ༭���л��Ƽ�ⷶΧ
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        // ����������Ұ
        Vector3 leftBoundary = Quaternion.Euler(0, 0, -fieldOfView / 2) * transform.right * detectionRange;
        Vector3 rightBoundary = Quaternion.Euler(0, 0, fieldOfView / 2) * transform.right * detectionRange;
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);
    }
}
