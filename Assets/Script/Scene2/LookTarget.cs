using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class LookTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target1; // 第一个目标物体
    public Transform target2; // 第二个目标物体
    public float speed = 1f; // 移动速度
    public Camera mainCamera;
    public CinemachineVirtualCamera virtualCamera;
    public float maxLens = 50f;
    public float minLens = 50f;// 最大镜头值
    public float lensIncreaseSpeed = 1f; // 镜头增加速度
    public float lensIncreaseSpeedRate = 1f;
    private float lens;
   // 初始镜头值
    void Start() {
        // 计算两个目标物体的中间位置
        lens = virtualCamera.m_Lens.OrthographicSize;


    }

    void Update() {
        Vector3 currentPosition = transform.position;
        Vector3 player1InView = mainCamera.WorldToViewportPoint(target1.position);
        Vector3 player2InView = mainCamera.WorldToViewportPoint(target2.position);


        Debug.Log(player1InView);


        // 计算两个目标物体的中间位置（只在y轴上平均，x轴保持不变）
        if (!IsInCameraView(player1InView) || !IsInCameraView(player2InView)) {
            // 增加镜头值
            lens += lensIncreaseSpeed * Time.deltaTime;

            // 限制镜头值
            lens = Mathf.Clamp(lens, minLens, maxLens);
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, lens, lensIncreaseSpeedRate * Time.deltaTime);
        }
 

       else if(IsOutCameraView(player1InView) || IsOutCameraView(player2InView)) {

            lens -= lensIncreaseSpeed * Time.deltaTime;

            // 限制镜头值
            lens = Mathf.Clamp(lens, minLens, maxLens);
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, lens, lensIncreaseSpeedRate * Time.deltaTime);
        }



        float midpointY = (target1.position.y + target2.position.y) / 2f;
        Vector3 midpoint = new Vector3(currentPosition.x, midpointY, currentPosition.z);

        // 使用Vector3.Lerp使物体平滑移动到中间位置
        transform.position = Vector3.Lerp(currentPosition, midpoint, speed * Time.deltaTime);
    }

    bool IsInCameraView(Vector3 point) {
        // 检查屏幕空间坐标是否在 (0, 0, 1, 1) 范围内
        return point.x >= 0.2f && point.x <= 0.8f && point.y >= 0.2f && point.y <= 0.8f;
    }

    bool IsOutCameraView(Vector3 point) {
        // 检查屏幕空间坐标是否在 (0, 0, 1, 1) 范围内
        return point.x >= 0.3f && point.x <= 0.7f && point.y >= 0.3f && point.y <= 0.7f;
    }



}
