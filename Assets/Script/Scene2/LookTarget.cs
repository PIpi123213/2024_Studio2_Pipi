using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class LookTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target1; // ��һ��Ŀ������
    public Transform target2; // �ڶ���Ŀ������
    public float speed = 1f; // �ƶ��ٶ�
    public Camera mainCamera;
    public CinemachineVirtualCamera virtualCamera;
    public float maxLens = 50f;
    public float minLens = 50f;// ���ͷֵ
    public float lensIncreaseSpeed = 1f; // ��ͷ�����ٶ�
    public float lensIncreaseSpeedRate = 1f;//ƽ��
    private float lens;
    private float lens1;
    private float lens2;
    // ��ʼ��ͷֵ
    void Start() {
        // ��������Ŀ��������м�λ��
        lens = minLens;
        lens1 = 2.2f;
        lens2 = maxLens;
    }

    void Update() {
        Vector3 currentPosition = transform.position;
        Vector3 player1InView = mainCamera.WorldToViewportPoint(target1.position);
        Vector3 player2InView = mainCamera.WorldToViewportPoint(target2.position);


        Debug.Log(player1InView);


        // ��������Ŀ��������м�λ�ã�ֻ��y����ƽ����x�ᱣ�ֲ��䣩
        if (!IsInCameraView(player1InView) || !IsInCameraView(player2InView)) {
            // ���Ӿ�ͷֵ
            if (virtualCamera.m_Lens.OrthographicSize >=lens&& virtualCamera.m_Lens.OrthographicSize < lens1)
            {
                virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, lens1+0.1f, lensIncreaseSpeedRate * Time.deltaTime*0.7f);
            }
            if(virtualCamera.m_Lens.OrthographicSize >= lens1 && virtualCamera.m_Lens.OrthographicSize < lens2)
            {
                virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, lens2, lensIncreaseSpeedRate * Time.deltaTime * 0.7f);
            }

            virtualCamera.m_Lens.OrthographicSize = Mathf.Clamp(virtualCamera.m_Lens.OrthographicSize, lens, lens2);

            /* lens += lensIncreaseSpeed * Time.deltaTime;

             // ���ƾ�ͷֵ
             lens = Mathf.Clamp(lens, minLens, maxLens);*/

        }
 

       else if(IsOutCameraView(player1InView) || IsOutCameraView(player2InView)) {

            if (virtualCamera.m_Lens.OrthographicSize > lens1 && virtualCamera.m_Lens.OrthographicSize <= lens2)
            {
                virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, lens1-0.1f, lensIncreaseSpeedRate * Time.deltaTime);
            }
            if (virtualCamera.m_Lens.OrthographicSize > lens && virtualCamera.m_Lens.OrthographicSize <= lens1)
            {
                virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, lens, lensIncreaseSpeedRate * Time.deltaTime);
            }


            virtualCamera.m_Lens.OrthographicSize = Mathf.Clamp(virtualCamera.m_Lens.OrthographicSize, lens, lens2);

        }
        /*if (!IsInCameraView(player1InView) || !IsInCameraView(player2InView))
        {
            // ���Ӿ�ͷֵ
            lens += lensIncreaseSpeed * Time.deltaTime;

            // ���ƾ�ͷֵ
            lens = Mathf.Clamp(lens, minLens, maxLens);
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, lens, lensIncreaseSpeedRate * Time.deltaTime);
        }


        else if (IsOutCameraView(player1InView) || IsOutCameraView(player2InView))
        {

            lens -= lensIncreaseSpeed * Time.deltaTime;

            // ���ƾ�ͷֵ
            lens = Mathf.Clamp(lens, minLens, maxLens);
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, lens, lensIncreaseSpeedRate * Time.deltaTime);
        }*/




        float midpointY = (target1.position.y + target2.position.y) / 2f;
        Vector3 midpoint = new Vector3(currentPosition.x, midpointY, currentPosition.z);

        // ʹ��Vector3.Lerpʹ����ƽ���ƶ����м�λ��
        transform.position = Vector3.Lerp(currentPosition, midpoint, speed * Time.deltaTime);
    }

    bool IsInCameraView(Vector3 point) {
        // �����Ļ�ռ������Ƿ��� (0, 0, 1, 1) ��Χ��
        return  point.y >= 0.25f && point.y <= 0.8f;
    }

    bool IsOutCameraView(Vector3 point) {
        // �����Ļ�ռ������Ƿ��� (0, 0, 1, 1) ��Χ��
        return  point.y >= 0.38f && point.y <= 0.65f;
    }



}
