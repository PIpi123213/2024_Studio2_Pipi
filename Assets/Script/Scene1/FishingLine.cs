using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingLine : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform hookTransform; // 鱼钩的 Transform
    public Transform fishTransform; // 鱼的 Transform
    private LineRenderer lineRenderer;
    public float ropeLength;
    public float currentropeLength;
    public float fishLength;



    public float duration = 1.0f;
    private float timer = 0.0f; // 计时器
    // 颜色
    private Color startColor;
    private Color startColor2;

    // Renderer组件
    private Material lineMaterial;
    public Transform point;
    public Transform movepoint;
    private float currentSaturation;
    private float currentSaturation2;

    public Slider score;

    
    public float sRate = 1.0f;

    public GameObject key;




    void Start()
    {
        // 获取 LineRenderer 组件
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer != null && lineRenderer.material != null)
        {
            lineMaterial = lineRenderer.materials[0];
            // 初始化起始颜色
            startColor = lineMaterial.color ;
            //startColor2 = lineMaterial.GetColor("_Color2"); ;
        }
        // 设置 LineRenderer 的顶点数
        lineRenderer.positionCount = 2;
        ropeLength = Vector2.Distance(hookTransform.position, fishTransform.position) * 100f;
        currentropeLength = ropeLength;
        score.value = 0.1f;
    }

    void Update()
    {
        ropeLength = Vector2.Distance(hookTransform.position, fishTransform.position)*100f;

        // 设置 LineRenderer 的起点和终点位置
        lineRenderer.SetPosition(0, hookTransform.position);
        lineRenderer.SetPosition(1, fishTransform.position);
        lineRenderer.SetPosition(2, movepoint.position);
        //Debug.Log(Mathf.Abs(ropeLength - currentropeLength));
        Color originalColor = lineMaterial.color;
        Color originalColor2 = startColor2;
        Color.RGBToHSV(originalColor, out float h, out float s, out float v);
        //Color.RGBToHSV(originalColor2, out float h2, out float s2, out float v2);
        float startSaturation = Mathf.Abs(ropeLength - currentropeLength) * 0.05f * sRate;
       //Debug.Log(currentSaturation);
        if(ropeLength - currentropeLength >= 0) {
            if (startSaturation > 0.2f)
            {
                currentSaturation = Mathf.Lerp(s, startSaturation, 1f * Time.deltaTime);
                currentSaturation = Mathf.Clamp(currentSaturation, 0f, 1f);
                Color newColor = Color.HSVToRGB(0, currentSaturation, v);
                //lineMaterial.SetColor("_Color1", newColor);
                lineMaterial.color = newColor;
            }
            else
            {
                currentSaturation = Mathf.Lerp(s, 0f, 3f * Time.deltaTime);
                currentSaturation = Mathf.Clamp(currentSaturation, 0f, 1f);
                Color newColor = Color.HSVToRGB(0, currentSaturation, v);
                //lineMaterial.SetColor("_Color1", newColor);
                lineMaterial.color = newColor;
            }





        }
        else {
            if (startSaturation > 0.2f)
            {
                currentSaturation = Mathf.Lerp(s, startSaturation, 1f * Time.deltaTime);
                currentSaturation = Mathf.Clamp(currentSaturation, 0f, 1f);
                Color newColor = Color.HSVToRGB(48f / 255f, currentSaturation, v);
                //lineMaterial.SetColor("_Color1", newColor);
                lineMaterial.color = newColor;
            }
            else
            {
                currentSaturation = Mathf.Lerp(s, 0f, 3f * Time.deltaTime);
                currentSaturation = Mathf.Clamp(currentSaturation, 0f, 1f);
                Color newColor = Color.HSVToRGB(48f / 255f, currentSaturation, v);
                //lineMaterial.SetColor("_Color1", newColor);
                lineMaterial.color = newColor;
            }
        }






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





        // 线性插值计算当前饱和度


        //currentH = Mathf.Clamp(currentH, 8f, 55f);


        //lineMaterial.color = newColor;
        //Debug.Log("23123");
        //Debug.Log(h);



       
       

        // Debug.Log(currentSaturation);
        if (score.value != 1)
        {
            if (currentSaturation <= 0.2f)
            {
                score.value += 0.0007f;

            }
            else
            {
                score.value -= 0.0005f;
            }
        }
       
        if(score.value >= 1)
        {
            key.transform.SetParent(null);
            key.transform.position = Vector3.MoveTowards(key.transform.position, point.transform.position, 1.3f * Time.deltaTime);
            if (key.transform.position == point.transform.position)
            {
                Timelinescene11.player2win = true;
            }
            



        }
        else
        {
            if (currentSaturation >= 0.5f)

            {
                timer += Time.deltaTime;

                // 检查计时器是否达到阈值时长
                if (timer >= duration && currentSaturation >= 0.7f)
                {
                    Debug.Log("Saturation has been above the threshold for 1 second");
                    lineMaterial.color = Color.red;
                    // 触发你需要的逻辑，例如重置计时器
                    //GameManager.instance.GameOver();
                    Timelinescene11.isLose = true;
                    timer = 0.0f;
                }
                else
                {
                    // 如果条件不再满足，重置计时器
                    //timer = 0.0f;
                }
            }

        }














    }
}
