using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingLine : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform hookTransform; // �㹳�� Transform
    public Transform fishTransform; // ��� Transform
    private LineRenderer lineRenderer;
    public float ropeLength;
    public float currentropeLength;
    public float fishLength;



    public float duration = 2.0f;

    // ��ɫ
    private Color startColor;
    private Color targetColor1 = Color.yellow;
    private Color targetColor2 = Color.red;

    // ��������
    private bool shouldStartGradient = false;

    // Renderer���
    private Material lineMaterial;
    public Transform point;














    void Start()
    {
        // ��ȡ LineRenderer ���
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer != null && lineRenderer.material != null)
        {
            lineMaterial = lineRenderer.materials[0];
            // ��ʼ����ʼ��ɫ
            startColor = lineMaterial.color;
        }
        // ���� LineRenderer �Ķ�����
        lineRenderer.positionCount = 2;
        ropeLength = Vector2.Distance(hookTransform.position, fishTransform.position) * 100f;
        currentropeLength = ropeLength;
    }

    void Update()
    {
        ropeLength = Vector2.Distance(hookTransform.position, fishTransform.position)*100f;

        // ���� LineRenderer �������յ�λ��
        lineRenderer.SetPosition(0, hookTransform.position);
        lineRenderer.SetPosition(1, fishTransform.position);
        //Debug.Log(Mathf.Abs(ropeLength - currentropeLength));
        Color originalColor = startColor;
        Color.RGBToHSV(originalColor, out float h, out float s, out float v);
        if (Mathf.Abs(ropeLength - currentropeLength) >= fishLength)
        {
           
            float startSaturation = Mathf.Abs(ropeLength - currentropeLength)*0.07f;
            

            // ���Բ�ֵ���㵱ǰ���Ͷ�
            float currentSaturation = Mathf.Lerp(s, startSaturation, 10f * Time.deltaTime);
            
            //currentH = Mathf.Clamp(currentH, 8f, 55f);

            Color newColor = Color.HSVToRGB(h, currentSaturation, v);
            
            lineMaterial.color = newColor;
            //Debug.Log("23123");
            //Debug.Log(h);



        }
        else
        {
            float startSaturation = Mathf.Abs(ropeLength - currentropeLength)*0.07f;
            float startH = 100f / Mathf.Abs(ropeLength - currentropeLength);





            float currentSaturation = Mathf.Lerp(s, startSaturation, 10f* Time.deltaTime);


           
            Color newColor = Color.HSVToRGB(h, currentSaturation, v);
            lineMaterial.color = newColor;
            //Debug.Log(currentH);

        }













    }
}
