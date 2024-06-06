using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTargetScene3 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    //public float _speed = 1f;// �ƶ��ٶ�
    public Camera mainCamera;
    public CinemachineVirtualCamera virtualCamera;
    public float maxLens = 50f;
    public float minLens = 50f;// ���ͷֵ
    public float lensIncreaseSpeed = 1f; // ��ͷ�����ٶ�
    public float lensIncreaseSpeedRate = 1f;//ƽ��
    private float lens;
    private float lens1;
    private float lens2;
    private float lens3;
    public float y;
    public float y1;
    public float y2;
    private float midY;


    public GameObject player1; // ��һ��Ŀ������
    public GameObject player2;

    private Vector3 player1InView;
    private Vector3 player2InView;
   

    private bool isincrease = false;
    // ��ʼ��ͷֵ
    void Start() {
        // ��������Ŀ��������м�λ��
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

        
  
        // ��������Ŀ��������м�λ�ã�ֻ��y����ƽ����x�ᱣ�ֲ��䣩
        if (!IsInCameraView(player1InView) || !IsInCameraView(player2InView)) {
            // ���Ӿ�ͷֵ
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

            // ���ƾ�ͷֵ
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

        // ʹ��Vector3.Lerpʹ����ƽ���ƶ����м�λ��
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
        // �����Ļ�ռ������Ƿ��� (0, 0, 1, 1) ��Χ��
        return point.x >= 0.28f && point.x <= 0.85f;
    }

    bool IsOutCameraView(Vector3 point) {
        // �����Ļ�ռ������Ƿ��� (0, 0, 1, 1) ��Χ��
        return point.x >= 0.4f && point.x <= 0.73f;
    }

}
