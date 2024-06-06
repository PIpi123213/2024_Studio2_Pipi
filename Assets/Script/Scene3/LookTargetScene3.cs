using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTargetScene3 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    //public float _speed = 1f;// 移动速度
    public Camera mainCamera;
    public CinemachineVirtualCamera virtualCamera;
    public float maxLens = 50f;
    public float minLens = 50f;// 最大镜头值
    public float lensIncreaseSpeed = 1f; // 镜头增加速度
    public float lensIncreaseSpeedRate = 1f;//平缓
    private float lens;
    private float lens1;
    private float lens2;
    private float lens3;
    public float y;
    public float y1;
    public float y2;
    private float midY;


    public GameObject player1; // 第一个目标物体
    public GameObject player2;

    private Vector3 player1InView;
    private Vector3 player2InView;
   

    private bool isincrease = false;
    // 初始镜头值
    void Start() {
        // 计算两个目标物体的中间位置
        lens = minLens;
        lens1 = 4.6f;
        lens2 = maxLens;
        //lens3 = maxLens;
        midY = y;




    }
    private void FixedUpdate() {
       

    }



    void Update() {
        Vector3 currentPosition = transform.position;
        player1InView = mainCamera.WorldToViewportPoint(player1.transform.position);
        player2InView = mainCamera.WorldToViewportPoint(player2.transform.position);


        Debug.Log(player1InView);

        
  
        // 计算两个目标物体的中间位置（只在y轴上平均，x轴保持不变）
        if (!IsInCameraView(player1InView) || !IsInCameraView(player2InView)) {
            // 增加镜头值
            if (virtualCamera.m_Lens.OrthographicSize >= lens && virtualCamera.m_Lens.OrthographicSize < lens1 && !isincrease) {
                isincrease = true;
                StartCoroutine(SmoothZoom(virtualCamera.m_Lens.OrthographicSize, lens1, lensIncreaseSpeedRate * 0.6f));
                midY = y1;
            }
            if (virtualCamera.m_Lens.OrthographicSize >= lens1 && virtualCamera.m_Lens.OrthographicSize < lens2 && !isincrease) {
                isincrease = true;
                StartCoroutine(SmoothZoom(virtualCamera.m_Lens.OrthographicSize, lens2, lensIncreaseSpeedRate * 0.9f));
                midY = y2;
            }
            /*if (virtualCamera.m_Lens.OrthographicSize >= lens2 && virtualCamera.m_Lens.OrthographicSize < lens3 && !isincrease) {
                isincrease = true;
                StartCoroutine(SmoothZoom(virtualCamera.m_Lens.OrthographicSize, lens3, lensIncreaseSpeedRate));

            }*/





            //* lens += lensIncreaseSpeed * Time.deltaTime;

            // 限制镜头值
            //lens = Mathf.Clamp(lens, minLens, maxLens);

        }


        else if (IsOutCameraView(player1InView) && IsOutCameraView(player2InView)) {
/*
            if (virtualCamera.m_Lens.OrthographicSize > lens2 && virtualCamera.m_Lens.OrthographicSize <= lens3 && !isincrease) {
                isincrease = true;
                StartCoroutine(SmoothZoom(virtualCamera.m_Lens.OrthographicSize, lens2, lensIncreaseSpeedRate));
            }*/


            if (virtualCamera.m_Lens.OrthographicSize > lens1 && virtualCamera.m_Lens.OrthographicSize <= lens2 && !isincrease) {
                isincrease = true;
                StartCoroutine(SmoothZoom(virtualCamera.m_Lens.OrthographicSize, lens1, lensIncreaseSpeedRate * 0.9f));
                midY = y1;
            }
            if (virtualCamera.m_Lens.OrthographicSize > lens && virtualCamera.m_Lens.OrthographicSize <= lens1 && !isincrease) {
                isincrease = true;
                StartCoroutine(SmoothZoom(virtualCamera.m_Lens.OrthographicSize, lens, lensIncreaseSpeedRate * 0.6f));
                midY = y;
            }


            //virtualCamera.m_Lens.OrthographicSize = Mathf.Clamp(virtualCamera.m_Lens.OrthographicSize, lens, lens3);

        }
        


        float midpointx = (player1.transform.position.x + player2.transform.position.x) / 2f;
        Vector3 midpoint = new Vector3(midpointx, midY , currentPosition.z);

        // 使用Vector3.Lerp使物体平滑移动到中间位置
        transform.position = Vector3.Lerp(currentPosition, midpoint, speed * Time.deltaTime);
    }

    IEnumerator SmoothZoom(float startValue, float endValue, float duration) {
        float elapsed = 0f;

        while (elapsed < duration) {
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(startValue, endValue, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        isincrease = false;
        virtualCamera.m_Lens.OrthographicSize = endValue; // Ensure it reaches the end value
    }

    bool IsInCameraView(Vector3 point) {
        // 检查屏幕空间坐标是否在 (0, 0, 1, 1) 范围内
        return point.x >= 0.28f && point.x <= 0.85f;
    }

    bool IsOutCameraView(Vector3 point) {
        // 检查屏幕空间坐标是否在 (0, 0, 1, 1) 范围内
        return point.x >= 0.4f && point.x <= 0.73f;
    }

}
