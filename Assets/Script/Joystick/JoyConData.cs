using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyConData : MonoBehaviour
{
    public JoyconDemo JoyCon_Left;
    public JoyconDemo Joycon_Right;

    // �� JoyCon ����
    public static float leftDirection;  // ��ǰ�˶�����Ƕ� (0-360��)
    public static float leftSpeed;      // ת���ٶ� (��/��)
    public static int leftCircleCount;  // ����תȦ����

    // �� JoyCon ����
    public static float rightDirection;
    public static float rightSpeed;
    public static int rightCircleCount;

    private Vector3 lastLeftAccel;
    private Vector3 lastRightAccel;
    private float leftAngleSum;  // �ۼƽǶȱ仯�����ڼ������Ȧ��
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
        // ����΢С���ٶȱ仯
        if (currentAccel.magnitude < 0.2f)
        {
            direction = 0; // ��ת��
            speed = 0f;
            return;
        }

        // ���㵱ǰ�˶����򣨻��ڼ��ٶȵ� XZ ƽ��ͶӰ��
        Vector2 currentDir = new Vector2(currentAccel.x, currentAccel.z).normalized;
        Vector2 lastDir = new Vector2(lastAccel.x, lastAccel.z).normalized;

        // ���㷽��仯�Ƕȣ�ʹ�ò���͵����
        float angleChange = Vector2.SignedAngle(lastDir, currentDir);
        angleSum += angleChange;

        // ���㵱ǰ����0-360�㣩
        direction = angleChange == 0 ? 0 : (int)Mathf.Sign(angleChange);

        // ����ת���ٶȣ���/�룩
        speed = Mathf.Abs(angleChange) / Time.deltaTime;
       
        
        // �������תȦ���ۼƽǶȳ��� 360�㣩
        if (Mathf.Abs(angleSum) >= 360f)
        {
            circleCount += (int)Mathf.Sign(angleSum); // +1 ˳ʱ�룬-1 ��ʱ��
            angleSum -= 360f * Mathf.Sign(angleSum); // �����ۼƽǶ�
            Debug.Log($"Detected full circle! Direction: {(angleChange > 0 ? "Clockwise" : "Counter-Clockwise")}");
        }

        lastAccel = currentAccel;
    }

    // ����תȦ����
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
