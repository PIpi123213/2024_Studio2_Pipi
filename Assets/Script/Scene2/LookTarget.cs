using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class LookTarget : MonoBehaviour
{
    // Start is called before the first frame update
    // �ڶ���Ŀ������

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
    private float lens3;
    private Rigidbody2D rigidbody2;
    private Rigidbody2D rigidbody1;
    public GameObject player1; // ��һ��Ŀ������
    public GameObject player2;

    private Vector3 player1InView;
    private Vector3 player2InView;
    private float currentforce;

    private bool isincrease = false;
    // ��ʼ��ͷֵ
    void Start() {
        // ��������Ŀ��������м�λ��
        lens = minLens;
        lens1 = 2.38f;
        lens2 = 3f;
        lens3 = maxLens;
        rigidbody1 = player1.GetComponent<Rigidbody2D>();
        rigidbody2 = player2.GetComponent<Rigidbody2D>();




    }
    private void FixedUpdate()
    {
        if (player1.transform.position.y< player2.transform.position.y)
        {
            currentforce = player2.transform.position.y - player1.transform.position.y;

            currentforce = Mathf.Clamp(currentforce, 0f, 2f);
            rigidbody1.AddForce(Vector3.up * currentforce * 4f );

        }
        if (player1.transform.position.y > player2.transform.position.y)
        {

            currentforce = player1.transform.position.y - player2.transform.position.y;
            currentforce = Mathf.Clamp(currentforce, 0f, 2f);
            rigidbody2.AddForce(Vector3.up * currentforce * 4f);
            

        }

    }



    void Update() {
        Vector3 currentPosition = transform.position;
         player1InView = mainCamera.WorldToViewportPoint(player1.transform.position);
         player2InView = mainCamera.WorldToViewportPoint(player2.transform.position);


        //Debug.Log(player1InView);


        // ��������Ŀ��������м�λ�ã�ֻ��y����ƽ����x�ᱣ�ֲ��䣩
        if (!IsInCameraView(player1InView) || !IsInCameraView(player2InView)) {
            // ���Ӿ�ͷֵ
            if (virtualCamera.m_Lens.OrthographicSize >=lens&& virtualCamera.m_Lens.OrthographicSize < lens1 && !isincrease)
            {
                isincrease = true;
                StartCoroutine(SmoothZoom(virtualCamera.m_Lens.OrthographicSize, lens1, lensIncreaseSpeedRate*0.6f));
                
            }
            if(virtualCamera.m_Lens.OrthographicSize >= lens1 && virtualCamera.m_Lens.OrthographicSize < lens2 && !isincrease)
            {
                isincrease = true;
                StartCoroutine(SmoothZoom(virtualCamera.m_Lens.OrthographicSize, lens2, lensIncreaseSpeedRate * 0.9f));
             
            }
            if (virtualCamera.m_Lens.OrthographicSize >= lens2 && virtualCamera.m_Lens.OrthographicSize < lens3 && !isincrease)
            {
                isincrease = true;
                StartCoroutine(SmoothZoom(virtualCamera.m_Lens.OrthographicSize, lens3 , lensIncreaseSpeedRate));
               
            }
         


            

            //* lens += lensIncreaseSpeed * Time.deltaTime;

             // ���ƾ�ͷֵ
             //lens = Mathf.Clamp(lens, minLens, maxLens);

        }
 

       else if(IsOutCameraView(player1InView) && IsOutCameraView(player2InView)) {

            if (virtualCamera.m_Lens.OrthographicSize > lens2 && virtualCamera.m_Lens.OrthographicSize <= lens3 && !isincrease)
            {
                isincrease = true;
                StartCoroutine(SmoothZoom(virtualCamera.m_Lens.OrthographicSize, lens2, lensIncreaseSpeedRate));
            }


            if (virtualCamera.m_Lens.OrthographicSize > lens1 && virtualCamera.m_Lens.OrthographicSize <= lens2 && !isincrease)
            {
                isincrease = true;
                StartCoroutine(SmoothZoom(virtualCamera.m_Lens.OrthographicSize, lens1, lensIncreaseSpeedRate * 0.9f));
            }
            if (virtualCamera.m_Lens.OrthographicSize > lens && virtualCamera.m_Lens.OrthographicSize <= lens1 && !isincrease)
            {
                isincrease = true;
                StartCoroutine(SmoothZoom(virtualCamera.m_Lens.OrthographicSize, lens, lensIncreaseSpeedRate * 0.6f));
            }


            //virtualCamera.m_Lens.OrthographicSize = Mathf.Clamp(virtualCamera.m_Lens.OrthographicSize, lens, lens3);

        }
        /*if (!IsInCameraView(player1InView) || !IsInCameraView(player2InView))
        {
            // ���Ӿ�ͷֵ
            lens += lensIncreaseSpeed ;

            // ���ƾ�ͷֵ
            lens = Mathf.Clamp(lens, minLens, maxLens);
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, lens, lensIncreaseSpeedRate * Time.deltaTime);
        }


        else if (IsOutCameraView(player1InView) || IsOutCameraView(player2InView))
        {

            lens -= lensIncreaseSpeed ;

            // ���ƾ�ͷֵ
            lens = Mathf.Clamp(lens, minLens, maxLens);
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, lens, lensIncreaseSpeedRate * Time.deltaTime);
        }*/




        float midpointY = (player1.transform.position.y + player2.transform.position.y) / 2f;
        Vector3 midpoint = new Vector3(currentPosition.x, midpointY, currentPosition.z);

        // ʹ��Vector3.Lerpʹ����ƽ���ƶ����м�λ��
        transform.position = Vector3.Lerp(currentPosition, midpoint, speed * Time.deltaTime);
    }

    IEnumerator SmoothZoom(float startValue, float endValue, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(startValue, endValue, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        isincrease = false;
        virtualCamera.m_Lens.OrthographicSize = endValue; // Ensure it reaches the end value
    }

    bool IsInCameraView(Vector3 point) {
        // �����Ļ�ռ������Ƿ��� (0, 0, 1, 1) ��Χ��
        return  point.y >= 0.28f && point.y <= 0.85f;
    }

    bool IsOutCameraView(Vector3 point) {
        // �����Ļ�ռ������Ƿ��� (0, 0, 1, 1) ��Χ��
        return  point.y >= 0.4f && point.y <= 0.73f;
    }

   

}
