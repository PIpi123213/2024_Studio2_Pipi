using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyConData : MonoBehaviour
{
    public JoyconDemo JoyCon_Left;
    public JoyconDemo Joycon_Right;

    // 左 JoyCon 数据
    public static float leftDirection;  // 当前运动方向角度 (0-360°)
    public static float leftSpeed;      // 转动速度 (度/秒)
    public static int leftCircleCount;  // 完整转圈计数

    // 右 JoyCon 数据
    public static float rightDirection;
    public static float rightSpeed;
    public static int rightCircleCount;

    private Vector3 lastLeftAccel;
    private Vector3 lastRightAccel;
    private float leftAngleSum;  // 累计角度变化（用于检测完整圈）
    private float rightAngleSum;

    public float speed_test;
    public float direction_test;
    void Start()
    {
        lastLeftAccel = Vector3.zero;
        lastRightAccel = Vector3.zero;
        leftAngleSum = 0f;
        rightAngleSum = 0f;
        leftCircleCount = 0;
        rightCircleCount = 0;
    }

    void Update()
    {
        if (JoyCon_Left != null)
        {
            UpdateJoyconCircleDetection(
                JoyCon_Left.accel,
                ref lastLeftAccel,
                ref leftDirection,
                ref leftSpeed,
                ref leftAngleSum,
                ref leftCircleCount
            );
        }

        if (Joycon_Right != null)
        {
            UpdateJoyconCircleDetection(
                Joycon_Right.accel,
                ref lastRightAccel,
                ref rightDirection,
                ref rightSpeed,
                ref rightAngleSum,
                ref rightCircleCount
            );
        }
        direction_test = rightDirection;
        speed_test = rightSpeed;
    }

    void UpdateJoyconCircleDetection(
        Vector3 currentAccel,
        ref Vector3 lastAccel,
        ref float direction,
        ref float speed,
        ref float angleSum,
        ref int circleCount
    )
    {
        // 忽略微小加速度变化
        if (currentAccel.magnitude < 0.2f)
        {
            direction = 0; // 无转动
            speed = 0f;
            return;
        }

        // 计算当前运动方向（基于加速度的 XZ 平面投影）
        Vector2 currentDir = new Vector2(currentAccel.x, currentAccel.z).normalized;
        Vector2 lastDir = new Vector2(lastAccel.x, lastAccel.z).normalized;

        // 计算方向变化角度（使用叉积和点积）
        float angleChange = Vector2.SignedAngle(lastDir, currentDir);
        angleSum += angleChange;

        // 计算当前方向（0-360°）
        direction = angleChange == 0 ? 0 : (int)Mathf.Sign(angleChange);

        // 计算转动速度（度/秒）
        speed = Mathf.Abs(angleChange) / Time.deltaTime;
       
        
        // 检测完整转圈（累计角度超过 360°）
        if (Mathf.Abs(angleSum) >= 360f)
        {
            circleCount += (int)Mathf.Sign(angleSum); // +1 顺时针，-1 逆时针
            angleSum -= 360f * Mathf.Sign(angleSum); // 重置累计角度
            Debug.Log($"Detected full circle! Direction: {(angleChange > 0 ? "Clockwise" : "Counter-Clockwise")}");
        }

        lastAccel = currentAccel;
    }

    // 重置转圈计数
    public static void ResetCircleCount(bool isLeftJoycon)
    {
        if (isLeftJoycon)
        {
            leftCircleCount = 0;
        }
        else
        {
            rightCircleCount = 0;
        }
    }
}
