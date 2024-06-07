using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player1;            // 第一个玩家
    public Transform player2;            // 第二个玩家
    public float detectionRange = 10f;   // 检测范围
    public float fieldOfView = 45f;      // 视野角度
    public LayerMask playerLayer;        // 玩家层
    public LayerMask obstaclesLayer;     // 掩体层

    public bool isFind = false;
    private void Update()
    {
        DetectPlayer(player1);
        DetectPlayer(player2);
    }

    bool DetectPlayer(Transform player)
    {
        // 计算警察和玩家之间的距离
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // 如果玩家在检测范围内
        if (distanceToPlayer <= detectionRange)
        {
            // 计算从警察到玩家的方向
            Vector2 directionToPlayer = (player.position - transform.position).normalized;
            float angleToPlayer = Vector2.Angle(transform.right, directionToPlayer);

            // 检查玩家是否在视野锥内
            if (angleToPlayer <= fieldOfView / 2)
            {
                // 发射一条从警察到玩家的射线，只检测玩家层和障碍物层
                RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, detectionRange, playerLayer | obstaclesLayer);

                // 调试信息：显示射线检测结果
                Debug.DrawLine(transform.position, player.position, Color.red);

                // 检查射线是否击中了任何物体
                if (hit.collider != null)
                {
                    Debug.Log("射线击中了: " + hit.collider.gameObject.name);
                    // 检查射线是否击中了玩家
                    if (((1 << hit.collider.gameObject.layer) & playerLayer) != 0)
                    {
                        Debug.Log($"玩家 {player.name} 被发现！");
                        // 在这里添加玩家被发现后的处理逻辑
                        return true;
                    }
                    else
                    {
                        Debug.Log("射线未击中玩家，被其他物体阻挡。");
                        return false;
                    }
                }
                else
                {
                    Debug.Log("射线没有击中任何物体");
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

    // 可选：在编辑器中绘制检测范围
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        // 绘制扇形视野
        Vector3 leftBoundary = Quaternion.Euler(0, 0, -fieldOfView / 2) * transform.right * detectionRange;
        Vector3 rightBoundary = Quaternion.Euler(0, 0, fieldOfView / 2) * transform.right * detectionRange;
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);
    }
}
