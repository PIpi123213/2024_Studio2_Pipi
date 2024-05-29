using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingLine : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform hookTransform; // �㹳�� Transform
    public Transform fishTransform; // ��� Transform
    private LineRenderer lineRenderer;
    public float ropeLength;
    public float currentropeLength;
    public float fishLength;



    public float duration = 1.0f;
    private float timer = 0.0f; // ��ʱ��
    // ��ɫ
    private Color startColor;
    private Color startColor2;

    // Renderer���
    private Material lineMaterial;
    public Transform point;

    private float currentSaturation;
    private float currentSaturation2;

    public Slider score;









    void Start()
    {
        // ��ȡ LineRenderer ���
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer != null && lineRenderer.material != null)
        {
            lineMaterial = lineRenderer.materials[0];
            // ��ʼ����ʼ��ɫ
            startColor = lineMaterial.color ;
            //startColor2 = lineMaterial.GetColor("_Color2"); ;
        }
        // ���� LineRenderer �Ķ�����
        lineRenderer.positionCount = 2;
        ropeLength = Vector2.Distance(hookTransform.position, fishTransform.position) * 100f;
        currentropeLength = ropeLength;
        score.value = 0.2f;
    }

    void Update()
    {
        ropeLength = Vector2.Distance(hookTransform.position, fishTransform.position)*100f;

        // ���� LineRenderer �������յ�λ��
        lineRenderer.SetPosition(0, hookTransform.position);
        lineRenderer.SetPosition(1, fishTransform.position);
        //Debug.Log(Mathf.Abs(ropeLength - currentropeLength));
        Color originalColor = startColor;
        Color originalColor2 = startColor2;
        Color.RGBToHSV(originalColor, out float h, out float s, out float v);
        Color.RGBToHSV(originalColor2, out float h2, out float s2, out float v2);
        float startSaturation = Mathf.Abs(ropeLength - currentropeLength) * 0.07f;
        currentSaturation = Mathf.Lerp(s, startSaturation*1.2f , 5f * Time.deltaTime);
        currentSaturation = Mathf.Clamp(currentSaturation, 0f, 1f);
        Color newColor = Color.HSVToRGB(h, currentSaturation, v);
        //lineMaterial.SetColor("_Color1", newColor);
        lineMaterial.color = newColor;


        /*if (Mathf.Abs(ropeLength - currentropeLength) >= fishLength)
        {
             currentSaturation = Mathf.Lerp(s, startSaturation * 1.3f, 10f * Time.deltaTime);
             currentSaturation2 = Mathf.Lerp(s2, 0f, 10f * Time.deltaTime);
            Color newColor = Color.HSVToRGB(h, currentSaturation, v);
            lineMaterial.SetColor("_Color1", newColor);

            Color newColor2 = Color.HSVToRGB(h2, currentSaturation2, v2);


            lineMaterial.SetColor("_Color2", newColor2);

        }
        else if (Mathf.Abs(ropeLength - currentropeLength) >= 0f && Mathf.Abs(ropeLength - currentropeLength) <fishLength)
        {
            currentSaturation = Mathf.Lerp(s, 0f, 10f * Time.deltaTime);
             currentSaturation2 = Mathf.Lerp(s2, startSaturation * 1f, 10f * Time.deltaTime);
            Color newColor = Color.HSVToRGB(h, currentSaturation, v);
            lineMaterial.SetColor("_Color1", newColor);
            Color newColor2 = Color.HSVToRGB(h2, currentSaturation2, v2);


            lineMaterial.SetColor("_Color2", newColor2);
        }*/





        // ���Բ�ֵ���㵱ǰ���Ͷ�


        //currentH = Mathf.Clamp(currentH, 8f, 55f);


        //lineMaterial.color = newColor;
        //Debug.Log("23123");
        //Debug.Log(h);

        

        if (currentSaturation>=0.5f)

        {
            timer += Time.deltaTime;

            // ����ʱ���Ƿ�ﵽ��ֵʱ��
            if (timer >= duration&&currentSaturation>=0.75f)
            {
                Debug.Log("Saturation has been above the threshold for 1 second");
                // ��������Ҫ���߼����������ü�ʱ��
                timer = 0.0f;
            }
           
        }
        else
        {
            // ��������������㣬���ü�ʱ��
            //timer = 0.0f;
        }

       // Debug.Log(currentSaturation);

        if(currentSaturation <= 0.15f)
        {
            score.value += 0.0005f;

        }
        else
        {
            score.value -= 0.0005f;
        }
















    }
}
